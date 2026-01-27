"""Tests for uniqueid, mirroring UniqueIdTests.cs behavior and expected values."""

import unittest

from uniqueid import UniqueId

KEY_STRING = "test"
INVALID_MSG = "Invalid input string. Couldn't be empty or white space."


class TestUniqueId(unittest.TestCase):
    def test_origin_equals_input(self):
        uid = UniqueId(KEY_STRING)
        self.assertEqual(uid.get_origin(), KEY_STRING)

    def test_hash_not_null_or_empty(self):
        uid = UniqueId(KEY_STRING)
        self.assertTrue(uid.get_hash().strip())
        self.assertGreater(len(uid.get_hash()), 0)

    def test_rejects_none(self):
        with self.assertRaises(ValueError) as ctx:
            UniqueId(None)
        self.assertEqual(str(ctx.exception), INVALID_MSG)

    def test_rejects_empty(self):
        with self.assertRaises(ValueError) as ctx:
            UniqueId("")
        self.assertEqual(str(ctx.exception), INVALID_MSG)

    def test_rejects_whitespace_only(self):
        with self.assertRaises(ValueError) as ctx:
            UniqueId(" ")
        self.assertEqual(str(ctx.exception), INVALID_MSG)

    def test_id32_matches_reference(self):
        uid = UniqueId(KEY_STRING)
        self.assertEqual(uid.get_id(), 160394189)

    def test_id64_matches_reference(self):
        uid = UniqueId(KEY_STRING)
        self.assertEqual(uid.get_id64(), 688887797400064883)

    def test_same_input_same_ids(self):
        uid1 = UniqueId(KEY_STRING)
        uid2 = UniqueId(KEY_STRING)
        self.assertEqual(uid1.get_id(), uid2.get_id())
        self.assertEqual(uid1.get_id64(), uid2.get_id64())

    def test_test_vs_Test_different_ids(self):
        uid1 = UniqueId("test")
        uid2 = UniqueId("Test")
        self.assertNotEqual(uid1.get_id(), uid2.get_id())
        self.assertNotEqual(uid1.get_id64(), uid2.get_id64())

    def test_duplicate_string_different_ids(self):
        uid1 = UniqueId(KEY_STRING)
        uid2 = UniqueId(KEY_STRING + KEY_STRING)
        self.assertNotEqual(uid1.get_id(), uid2.get_id())
        self.assertNotEqual(uid1.get_id64(), uid2.get_id64())

    def test_trailing_space_different_ids(self):
        uid1 = UniqueId(KEY_STRING)
        uid2 = UniqueId("test ")
        self.assertNotEqual(uid1.get_id(), uid2.get_id())
        self.assertNotEqual(uid1.get_id64(), uid2.get_id64())

    def test_bulk_distinct_ids(self):
        # ASCII-only paragraph so encode('ascii') is valid
        words = (
            "Mussum Ipsum cacilds vidis litro abertis. Suco de cevadiss um leite "
            "divinis qui tem lupuliz matis aguis e fermentis. Leite de capivaris "
            "leite de mula manquis sem cabeca. Interagi no me cursus quis vehicula "
            "ac nisi. Ta deprimidis eu conheco uma cachacis que pode alegrar sua vidis."
        )
        table = {}
        for w in words.split():
            if w in table:
                continue
            table[w] = UniqueId(w)
        # All ids distinct for distinct words
        keys = list(table.keys())
        for i, k1 in enumerate(keys):
            for k2 in keys[i + 1 :]:
                self.assertNotEqual(
                    table[k1].get_id(),
                    table[k2].get_id(),
                    f"get_id collision for {k1!r} vs {k2!r}",
                )
                self.assertNotEqual(
                    table[k1].get_id64(),
                    table[k2].get_id64(),
                    f"get_id64 collision for {k1!r} vs {k2!r}",
                )


if __name__ == "__main__":
    unittest.main()
