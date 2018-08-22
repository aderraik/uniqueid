using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UniqueIdTests
{
	[TestClass()]
	public class UniqueIdTests
	{
		private const string KeyString = "test";

		[TestMethod()]
		public void IdsStringAreEqual()
		{
			var id = new UniqueId.UniqueId(KeyString);
			Assert.IsTrue(id.GetOrigin() == KeyString);
		}

		[TestMethod()]
		public void HashNotNullOrEmpty()
		{
			var id = new UniqueId.UniqueId(KeyString);
			Assert.IsFalse(string.IsNullOrWhiteSpace(id.GetHash()));
		}

		[TestMethod()]
		[ExpectedException(typeof(ArgumentException))]
		public void IdsIsNull()
		{
			// ReSharper disable once UnusedVariable
			var id = new UniqueId.UniqueId(null);
		}

		[TestMethod()]
		[ExpectedException(typeof(ArgumentException))]
		public void IdsIsEmpty()
		{
			// ReSharper disable once UnusedVariable
			var id = new UniqueId.UniqueId(string.Empty);
		}

		[TestMethod()]
		[ExpectedException(typeof(ArgumentException))]
		public void IdsIsSpace()
		{
			// ReSharper disable once UnusedVariable
			var id = new UniqueId.UniqueId(" ");
		}

		[TestMethod()]
		public void Id32IsTheSame()
		{
			var id = new UniqueId.UniqueId(KeyString);
			Assert.IsTrue(id.GetId() == 160394189);
		}

		[TestMethod()]
		public void Id64IsTheSame()
		{
			var id = new UniqueId.UniqueId(KeyString);
			Assert.IsTrue(id.GetId64() == 688887797400064883);
		}

		[TestMethod()]
		public void IdsAreEquals()
		{
			var id1 = new UniqueId.UniqueId(KeyString);
			var id2 = new UniqueId.UniqueId(KeyString);
			Assert.IsTrue(id1.GetId() == id2.GetId());
			Assert.IsTrue(id1.GetId64() == id2.GetId64());
		}

		[TestMethod()]
		public void IdsWithOneLetterUppercaseAreDifferents()
		{
			var id1 = new UniqueId.UniqueId("test");
			var id2 = new UniqueId.UniqueId("Test");
			Assert.IsTrue(id1.GetId() != id2.GetId());
			Assert.IsTrue(id1.GetId64() != id2.GetId64());
		}

		[TestMethod()]
		public void IdsDuplicatesStringAreDifferents()
		{
			var id1 = new UniqueId.UniqueId(KeyString);
			var id2 = new UniqueId.UniqueId($"{KeyString}{KeyString}");
			Assert.IsTrue(id1.GetId() != id2.GetId());
			Assert.IsTrue(id1.GetId64() != id2.GetId64());
		}

		[TestMethod()]
		public void IdsWithSpaceAreDifferents()
		{
			var id1 = new UniqueId.UniqueId(KeyString);
			var id2 = new UniqueId.UniqueId("test ");
			Assert.IsTrue(id1.GetId() != id2.GetId());
			Assert.IsTrue(id1.GetId64() != id2.GetId64());
		}

		[TestMethod()]
		public void CreateBulkOfDifferentIds()
		{
			const string words = @"Mussum Ipsum, cacilds vidis litro abertis. Suco de cevadiss, é um leite divinis, qui tem lupuliz, matis, aguis e fermentis. Leite de capivaris, leite de mula manquis sem cabeça. Interagi no mé, cursus quis, vehicula ac nisi. Tá deprimidis, eu conheço uma cachacis que pode alegrar sua vidis.
Paisis, filhis, espiritis santis. Todo mundo vê os porris que eu tomo, mas ninguém vê os tombis que eu levo! Suco de cevadiss deixa as pessoas mais interessantis. Mauris nec dolor in eros commodo tempor. Aenean aliquam molestie leo, vitae iaculis nisl.
Em pé sem cair, deitado sem dormir, sentado sem cochilar e fazendo pose. Praesent vel viverra nisi. Mauris aliquet nunc non turpis scelerisque, eget. Nec orci ornare consequat. Praesent lacinia ultrices consectetur. Sed non ipsum felis. Cevadis im ampola pa arma uma pindureta.
Per aumento de cachacis, eu reclamis. Aenean aliquam molestie leo, vitae iaculis nisl. Quem manda na minha terra sou euzis! Posuere libero varius. Nullam a nisl ut ante blandit hendrerit. Aenean sit amet nisi.
Manduma pindureta quium dia nois paga. Copo furadis é disculpa de bebadis, arcu quam euismod magna. Admodum accumsan disputationi eu sit. Vide electram sadipscing et per. A ordem dos tratores não altera o pão duris.
Delegadis gente finis, bibendum egestas augue arcu ut est. Nullam volutpat risus nec leo commodo, ut interdum diam laoreet. Sed non consequat odio. Atirei o pau no gatis, per gatis num morreus. Pra lá , depois divoltis porris, paradis.
Praesent malesuada urna nisi, quis volutpat erat hendrerit non. Nam vulputate dapibus. Interessantiss quisso pudia ce receita de bolis, mais bolis eu num gostis. In elementis mé pra quem é amistosis quis leo. Detraxit consequat et quo num tendi nada.
Não sou faixa preta cumpadi, sou preto inteiris, inteiris. Si num tem leite então bota uma pinga aí cumpadi! Casamentiss faiz malandris se pirulitá. Mais vale um bebadis conhecidiss, que um alcoolatra anonimis.
Mé faiz elementum girarzis, nisi eros vermeio. Quem num gosta di mé, boa gentis num é. Quem num gosta di mim que vai caçá sua turmis! Diuretics paradis num copo é motivis de denguis.
Si u mundo tá muito paradis? Toma um mé que o mundo vai girarzis! Sapien in monti palavris qui num significa nadis i pareci latim. Vehicula non. Ut sed ex eros. Vivamus sit amet nibh non tellus tristique interdum. Viva Forevis aptent taciti sociosqu ad litora torquent.";

			// Create a list of ids
			var table = new Dictionary<string, UniqueId.UniqueId>();
			foreach (var w in words.Split(' '))
			{
				var id = new UniqueId.UniqueId(w);
				if (table.ContainsKey(w)) continue;
				table[w] = id;
			}
			Console.WriteLine("Number of ids:" + table.Count);

			// Check all generated ids
			foreach (var key in table.Keys)
			{
				foreach (var key2 in table.Keys)
				{
					if (key == key2) continue;
					Assert.IsTrue(table[key].GetId() != table[key2].GetId());
					Assert.IsTrue(table[key].GetId64() != table[key2].GetId64());
				}
			}
		}
	}
}