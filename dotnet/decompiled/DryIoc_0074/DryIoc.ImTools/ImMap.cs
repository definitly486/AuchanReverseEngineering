using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace DryIoc.ImTools;

public class ImMap<V>
{
	internal sealed class Leaf2 : ImMap<V>
	{
		public readonly ImMapEntry<V> Entry0;

		public readonly ImMapEntry<V> Entry1;

		public Leaf2(ImMapEntry<V> e0, ImMapEntry<V> e1)
		{
			Entry0 = e0;
			Entry1 = e1;
		}

		public override int Count()
		{
			return 2;
		}

		public override string ToString()
		{
			return "{L2:{E0: " + Entry0?.ToString() + ",E1:" + Entry1?.ToString() + "}}";
		}

		internal override ImMapEntry<V> GetMinHashEntryOrDefault()
		{
			return Entry0;
		}

		internal override ImMapEntry<V> GetMaxHashEntryOrDefault()
		{
			return Entry1;
		}

		internal override ImMapEntry<V> GetEntryOrNull(int hash)
		{
			if (Entry0.Hash != hash)
			{
				if (Entry1.Hash != hash)
				{
					return null;
				}
				return Entry1;
			}
			return Entry0;
		}

		internal override ImMap<V> AddOrGetEntry(int hash, ImMapEntry<V> entry)
		{
			if (hash != Entry0.Hash)
			{
				if (hash != Entry1.Hash)
				{
					return new Leaf2Plus1(entry, this);
				}
				return Entry1;
			}
			return Entry0;
		}

		internal override ImMap<V> ReplaceEntry(int hash, ImMapEntry<V> oldEntry, ImMapEntry<V> newEntry)
		{
			if (oldEntry != Entry0)
			{
				return new Leaf2(Entry0, newEntry);
			}
			return new Leaf2(newEntry, Entry1);
		}

		internal override ImMap<V> RemoveEntry(ImMapEntry<V> removedEntry)
		{
			if (Entry0 != removedEntry)
			{
				return Entry0;
			}
			return Entry1;
		}
	}

	internal sealed class Leaf2Plus1 : ImMap<V>
	{
		public readonly ImMapEntry<V> Plus;

		public readonly Leaf2 L;

		public Leaf2Plus1(ImMapEntry<V> plus, Leaf2 leaf)
		{
			Plus = plus;
			L = leaf;
		}

		public override int Count()
		{
			return 3;
		}

		public override string ToString()
		{
			return "{L21: {P: " + Plus?.ToString() + ", L: " + L?.ToString() + "}}";
		}

		internal override ImMapEntry<V> GetMinHashEntryOrDefault()
		{
			if (Plus.Hash >= L.Entry0.Hash)
			{
				return L.Entry0;
			}
			return Plus;
		}

		internal override ImMapEntry<V> GetMaxHashEntryOrDefault()
		{
			if (Plus.Hash <= L.Entry1.Hash)
			{
				return L.Entry1;
			}
			return Plus;
		}

		internal override ImMapEntry<V> GetEntryOrNull(int hash)
		{
			if (hash == Plus.Hash)
			{
				return Plus;
			}
			ImMapEntry<V> entry = L.Entry0;
			ImMapEntry<V> entry2 = L.Entry1;
			if (entry.Hash != hash)
			{
				if (entry2.Hash != hash)
				{
					return null;
				}
				return entry2;
			}
			return entry;
		}

		internal override ImMap<V> AddOrGetEntry(int hash, ImMapEntry<V> entry)
		{
			ImMapEntry<V> plus = Plus;
			if (hash == plus.Hash)
			{
				return plus;
			}
			ImMapEntry<V> entry2 = L.Entry0;
			ImMapEntry<V> entry3 = L.Entry1;
			if (hash != entry2.Hash)
			{
				if (hash != entry3.Hash)
				{
					return new Leaf2Plus1Plus1(entry, this);
				}
				return entry3;
			}
			return entry2;
		}

		internal override ImMap<V> ReplaceEntry(int hash, ImMapEntry<V> oldEntry, ImMapEntry<V> newEntry)
		{
			if (oldEntry != Plus)
			{
				if (oldEntry != L.Entry0)
				{
					return new Leaf2Plus1(Plus, new Leaf2(L.Entry0, newEntry));
				}
				return new Leaf2Plus1(Plus, new Leaf2(newEntry, L.Entry1));
			}
			return new Leaf2Plus1(newEntry, L);
		}

		internal override ImMap<V> RemoveEntry(ImMapEntry<V> removedEntry)
		{
			if (removedEntry != Plus)
			{
				if (removedEntry != L.Entry0)
				{
					if (Plus.Hash >= L.Entry0.Hash)
					{
						return new Leaf2(L.Entry0, Plus);
					}
					return new Leaf2(Plus, L.Entry0);
				}
				if (Plus.Hash >= L.Entry1.Hash)
				{
					return new Leaf2(L.Entry1, Plus);
				}
				return new Leaf2(Plus, L.Entry1);
			}
			return L;
		}
	}

	internal sealed class Leaf2Plus1Plus1 : ImMap<V>
	{
		public readonly ImMapEntry<V> Plus;

		public readonly Leaf2Plus1 L;

		public Leaf2Plus1Plus1(ImMapEntry<V> plus, Leaf2Plus1 l)
		{
			Plus = plus;
			L = l;
		}

		public override int Count()
		{
			return 4;
		}

		public override string ToString()
		{
			return "{L211:{P:" + Plus?.ToString() + ",L:" + L?.ToString() + "}}";
		}

		internal override ImMapEntry<V> GetMinHashEntryOrDefault()
		{
			ImMapEntry<V> plus = Plus;
			ImMapEntry<V> plus2 = L.Plus;
			ImMapEntry<V> entry = L.L.Entry0;
			if (plus.Hash >= plus2.Hash)
			{
				if (plus2.Hash >= entry.Hash)
				{
					return entry;
				}
				return plus2;
			}
			if (plus.Hash >= entry.Hash)
			{
				return entry;
			}
			return plus;
		}

		internal override ImMapEntry<V> GetMaxHashEntryOrDefault()
		{
			ImMapEntry<V> plus = Plus;
			ImMapEntry<V> plus2 = L.Plus;
			ImMapEntry<V> entry = L.L.Entry1;
			if (plus.Hash <= plus2.Hash)
			{
				if (plus2.Hash <= entry.Hash)
				{
					return entry;
				}
				return plus2;
			}
			if (plus.Hash <= entry.Hash)
			{
				return entry;
			}
			return plus;
		}

		internal override ImMapEntry<V> GetEntryOrNull(int hash)
		{
			if (hash == Plus.Hash)
			{
				return Plus;
			}
			if (hash == L.Plus.Hash)
			{
				return L.Plus;
			}
			Leaf2 l = L.L;
			ImMapEntry<V> entry = l.Entry0;
			ImMapEntry<V> entry2 = l.Entry1;
			if (entry.Hash != hash)
			{
				if (entry2.Hash != hash)
				{
					return null;
				}
				return entry2;
			}
			return entry;
		}

		internal override ImMap<V> AddOrGetEntry(int hash, ImMapEntry<V> entry)
		{
			ImMapEntry<V> imMapEntry = Plus;
			int hash2 = imMapEntry.Hash;
			if (hash2 == hash)
			{
				return imMapEntry;
			}
			ImMapEntry<V> imMapEntry2 = L.Plus;
			int hash3 = imMapEntry2.Hash;
			if (hash3 == hash)
			{
				return imMapEntry2;
			}
			Leaf2 l = L.L;
			ImMapEntry<V> imMapEntry3 = l.Entry0;
			ImMapEntry<V> imMapEntry4 = l.Entry1;
			if (hash == imMapEntry3.Hash)
			{
				return imMapEntry3;
			}
			if (hash == imMapEntry4.Hash)
			{
				return imMapEntry4;
			}
			ImMapEntry<V> imMapEntry5 = null;
			if (hash3 < imMapEntry4.Hash)
			{
				imMapEntry5 = imMapEntry4;
				imMapEntry4 = imMapEntry2;
				imMapEntry2 = imMapEntry5;
				if (hash3 < imMapEntry3.Hash)
				{
					imMapEntry5 = imMapEntry3;
					imMapEntry3 = imMapEntry4;
					imMapEntry4 = imMapEntry5;
				}
			}
			if (hash2 < imMapEntry2.Hash)
			{
				imMapEntry5 = imMapEntry2;
				imMapEntry2 = imMapEntry;
				imMapEntry = imMapEntry5;
				if (hash2 < imMapEntry4.Hash)
				{
					imMapEntry5 = imMapEntry4;
					imMapEntry4 = imMapEntry2;
					imMapEntry2 = imMapEntry5;
					if (hash2 < imMapEntry3.Hash)
					{
						imMapEntry5 = imMapEntry3;
						imMapEntry3 = imMapEntry4;
						imMapEntry4 = imMapEntry5;
					}
				}
			}
			ImMapEntry<V> imMapEntry6 = entry;
			if (hash < imMapEntry.Hash)
			{
				imMapEntry5 = imMapEntry;
				imMapEntry = imMapEntry6;
				imMapEntry6 = imMapEntry5;
				if (hash < imMapEntry2.Hash)
				{
					imMapEntry5 = imMapEntry2;
					imMapEntry2 = imMapEntry;
					imMapEntry = imMapEntry5;
					if (hash < imMapEntry4.Hash)
					{
						imMapEntry5 = imMapEntry4;
						imMapEntry4 = imMapEntry2;
						imMapEntry2 = imMapEntry5;
						if (hash < imMapEntry3.Hash)
						{
							imMapEntry5 = imMapEntry3;
							imMapEntry3 = imMapEntry4;
							imMapEntry4 = imMapEntry5;
						}
					}
				}
			}
			return new Leaf5(imMapEntry3, imMapEntry4, imMapEntry2, imMapEntry, imMapEntry6);
		}

		internal override ImMap<V> ReplaceEntry(int hash, ImMapEntry<V> oldEntry, ImMapEntry<V> newEntry)
		{
			if (oldEntry != Plus)
			{
				if (oldEntry != L.Plus)
				{
					if (oldEntry != L.L.Entry0)
					{
						return new Leaf2Plus1Plus1(Plus, new Leaf2Plus1(L.Plus, new Leaf2(L.L.Entry0, newEntry)));
					}
					return new Leaf2Plus1Plus1(Plus, new Leaf2Plus1(L.Plus, new Leaf2(newEntry, L.L.Entry1)));
				}
				return new Leaf2Plus1Plus1(Plus, new Leaf2Plus1(newEntry, L.L));
			}
			return new Leaf2Plus1Plus1(newEntry, L);
		}

		internal override ImMap<V> RemoveEntry(ImMapEntry<V> removedEntry)
		{
			if (removedEntry != Plus)
			{
				if (removedEntry != L.Plus)
				{
					if (removedEntry != L.L.Entry0)
					{
						if (L.Plus.Hash >= L.L.Entry0.Hash)
						{
							return new Leaf2Plus1(Plus, new Leaf2(L.L.Entry0, L.Plus));
						}
						return new Leaf2Plus1(Plus, new Leaf2(L.Plus, L.L.Entry0));
					}
					if (L.Plus.Hash >= L.L.Entry1.Hash)
					{
						return new Leaf2Plus1(Plus, new Leaf2(L.L.Entry1, L.Plus));
					}
					return new Leaf2Plus1(Plus, new Leaf2(L.Plus, L.L.Entry1));
				}
				return new Leaf2Plus1(Plus, L.L);
			}
			return L;
		}
	}

	internal sealed class Leaf5 : ImMap<V>
	{
		public readonly ImMapEntry<V> Entry0;

		public readonly ImMapEntry<V> Entry1;

		public readonly ImMapEntry<V> Entry2;

		public readonly ImMapEntry<V> Entry3;

		public readonly ImMapEntry<V> Entry4;

		public Leaf5(ImMapEntry<V> e0, ImMapEntry<V> e1, ImMapEntry<V> e2, ImMapEntry<V> e3, ImMapEntry<V> e4)
		{
			Entry0 = e0;
			Entry1 = e1;
			Entry2 = e2;
			Entry3 = e3;
			Entry4 = e4;
		}

		public override int Count()
		{
			return 5;
		}

		public override string ToString()
		{
			return "{L2:{E0:" + Entry0?.ToString() + ",E1:" + Entry1?.ToString() + ",E2:" + Entry2?.ToString() + ",E3:" + Entry3?.ToString() + ",E4:" + Entry4?.ToString() + "}}";
		}

		internal override ImMapEntry<V> GetMinHashEntryOrDefault()
		{
			return Entry0;
		}

		internal override ImMapEntry<V> GetMaxHashEntryOrDefault()
		{
			return Entry4;
		}

		internal override ImMapEntry<V> GetEntryOrNull(int hash)
		{
			if (hash != Entry0.Hash)
			{
				if (hash != Entry1.Hash)
				{
					if (hash != Entry2.Hash)
					{
						if (hash != Entry3.Hash)
						{
							if (hash != Entry4.Hash)
							{
								return null;
							}
							return Entry4;
						}
						return Entry3;
					}
					return Entry2;
				}
				return Entry1;
			}
			return Entry0;
		}

		internal override ImMap<V> AddOrGetEntry(int hash, ImMapEntry<V> entry)
		{
			if (hash != Entry0.Hash)
			{
				if (hash != Entry1.Hash)
				{
					if (hash != Entry2.Hash)
					{
						if (hash != Entry3.Hash)
						{
							if (hash != Entry4.Hash)
							{
								return new Leaf5Plus1(entry, this);
							}
							return Entry4;
						}
						return Entry3;
					}
					return Entry2;
				}
				return Entry1;
			}
			return Entry0;
		}

		internal override ImMap<V> ReplaceEntry(int hash, ImMapEntry<V> oldEntry, ImMapEntry<V> newEntry)
		{
			if (oldEntry != Entry0)
			{
				if (oldEntry != Entry1)
				{
					if (oldEntry != Entry2)
					{
						if (oldEntry != Entry3)
						{
							return new Leaf5(Entry0, Entry1, Entry2, Entry3, newEntry);
						}
						return new Leaf5(Entry0, Entry1, Entry2, newEntry, Entry4);
					}
					return new Leaf5(Entry0, Entry1, newEntry, Entry3, Entry4);
				}
				return new Leaf5(Entry0, newEntry, Entry2, Entry3, Entry4);
			}
			return new Leaf5(newEntry, Entry1, Entry2, Entry3, Entry4);
		}

		internal override ImMap<V> RemoveEntry(ImMapEntry<V> removedEntry)
		{
			if (removedEntry != Entry0)
			{
				if (removedEntry != Entry1)
				{
					if (removedEntry != Entry2)
					{
						if (removedEntry != Entry3)
						{
							return new Leaf2Plus1Plus1(Entry3, new Leaf2Plus1(Entry2, new Leaf2(Entry0, Entry1)));
						}
						return new Leaf2Plus1Plus1(Entry4, new Leaf2Plus1(Entry2, new Leaf2(Entry0, Entry1)));
					}
					return new Leaf2Plus1Plus1(Entry4, new Leaf2Plus1(Entry3, new Leaf2(Entry0, Entry1)));
				}
				return new Leaf2Plus1Plus1(Entry4, new Leaf2Plus1(Entry3, new Leaf2(Entry0, Entry2)));
			}
			return new Leaf2Plus1Plus1(Entry4, new Leaf2Plus1(Entry3, new Leaf2(Entry1, Entry2)));
		}
	}

	internal sealed class Leaf5Plus1 : ImMap<V>
	{
		public readonly ImMapEntry<V> Plus;

		public readonly Leaf5 L;

		public Leaf5Plus1(ImMapEntry<V> plus, Leaf5 l)
		{
			Plus = plus;
			L = l;
		}

		public override int Count()
		{
			return 6;
		}

		public override string ToString()
		{
			return "{L51:{P:" + Plus?.ToString() + ",L:" + L?.ToString() + "}}";
		}

		internal override ImMapEntry<V> GetMinHashEntryOrDefault()
		{
			if (Plus.Hash >= L.Entry0.Hash)
			{
				return L.Entry0;
			}
			return Plus;
		}

		internal override ImMapEntry<V> GetMaxHashEntryOrDefault()
		{
			if (Plus.Hash <= L.Entry4.Hash)
			{
				return L.Entry4;
			}
			return Plus;
		}

		internal override ImMapEntry<V> GetEntryOrNull(int hash)
		{
			if (hash == Plus.Hash)
			{
				return Plus;
			}
			Leaf5 l = L;
			if (hash != l.Entry0.Hash)
			{
				if (hash != l.Entry1.Hash)
				{
					if (hash != l.Entry2.Hash)
					{
						if (hash != l.Entry3.Hash)
						{
							if (hash != l.Entry4.Hash)
							{
								return null;
							}
							return l.Entry4;
						}
						return l.Entry3;
					}
					return l.Entry2;
				}
				return l.Entry1;
			}
			return l.Entry0;
		}

		internal override ImMap<V> AddOrGetEntry(int hash, ImMapEntry<V> entry)
		{
			ImMapEntry<V> plus = Plus;
			int hash2 = plus.Hash;
			if (hash2 == hash)
			{
				return plus;
			}
			Leaf5 l = L;
			if (hash != l.Entry0.Hash)
			{
				if (hash != l.Entry1.Hash)
				{
					if (hash != l.Entry2.Hash)
					{
						if (hash != l.Entry3.Hash)
						{
							if (hash != l.Entry4.Hash)
							{
								return new Leaf5Plus1Plus1(entry, this);
							}
							return l.Entry4;
						}
						return l.Entry3;
					}
					return l.Entry2;
				}
				return l.Entry1;
			}
			return l.Entry0;
		}

		internal override ImMap<V> ReplaceEntry(int hash, ImMapEntry<V> oldEntry, ImMapEntry<V> newEntry)
		{
			ImMapEntry<V> plus = Plus;
			if (oldEntry == plus)
			{
				return new Leaf5Plus1(newEntry, L);
			}
			Leaf5 l = L;
			ImMapEntry<V> entry = l.Entry0;
			ImMapEntry<V> entry2 = l.Entry1;
			ImMapEntry<V> entry3 = l.Entry2;
			ImMapEntry<V> entry4 = l.Entry3;
			ImMapEntry<V> entry5 = l.Entry4;
			if (oldEntry != entry)
			{
				if (oldEntry != entry2)
				{
					if (oldEntry != entry3)
					{
						if (oldEntry != entry4)
						{
							return new Leaf5Plus1(plus, new Leaf5(entry, entry2, entry3, entry4, newEntry));
						}
						return new Leaf5Plus1(plus, new Leaf5(entry, entry2, entry3, newEntry, entry5));
					}
					return new Leaf5Plus1(plus, new Leaf5(entry, entry2, newEntry, entry4, entry5));
				}
				return new Leaf5Plus1(plus, new Leaf5(entry, newEntry, entry3, entry4, entry5));
			}
			return new Leaf5Plus1(plus, new Leaf5(newEntry, entry2, entry3, entry4, entry5));
		}

		internal override ImMap<V> RemoveEntry(ImMapEntry<V> removedEntry)
		{
			ImMapEntry<V> imMapEntry = Plus;
			if (imMapEntry == removedEntry)
			{
				return L;
			}
			int hash = imMapEntry.Hash;
			Leaf5 l = L;
			ImMapEntry<V> imMapEntry2 = l.Entry0;
			ImMapEntry<V> imMapEntry3 = l.Entry1;
			ImMapEntry<V> imMapEntry4 = l.Entry2;
			ImMapEntry<V> imMapEntry5 = l.Entry3;
			ImMapEntry<V> imMapEntry6 = l.Entry4;
			ImMapEntry<V> imMapEntry7 = null;
			if (hash < imMapEntry6.Hash)
			{
				imMapEntry7 = imMapEntry6;
				imMapEntry6 = imMapEntry;
				imMapEntry = imMapEntry7;
				if (hash < imMapEntry5.Hash)
				{
					imMapEntry7 = imMapEntry5;
					imMapEntry5 = imMapEntry6;
					imMapEntry6 = imMapEntry7;
					if (hash < imMapEntry4.Hash)
					{
						imMapEntry7 = imMapEntry4;
						imMapEntry4 = imMapEntry5;
						imMapEntry5 = imMapEntry7;
						if (hash < imMapEntry3.Hash)
						{
							imMapEntry7 = imMapEntry3;
							imMapEntry3 = imMapEntry4;
							imMapEntry4 = imMapEntry7;
							if (hash < imMapEntry2.Hash)
							{
								imMapEntry7 = imMapEntry2;
								imMapEntry2 = imMapEntry3;
								imMapEntry3 = imMapEntry7;
							}
						}
					}
				}
			}
			if (removedEntry != imMapEntry2)
			{
				if (removedEntry != imMapEntry3)
				{
					if (removedEntry != imMapEntry4)
					{
						if (removedEntry != imMapEntry5)
						{
							if (removedEntry != imMapEntry6)
							{
								return new Leaf5(imMapEntry2, imMapEntry3, imMapEntry4, imMapEntry5, imMapEntry6);
							}
							return new Leaf5(imMapEntry2, imMapEntry3, imMapEntry4, imMapEntry5, imMapEntry);
						}
						return new Leaf5(imMapEntry2, imMapEntry3, imMapEntry4, imMapEntry6, imMapEntry);
					}
					return new Leaf5(imMapEntry2, imMapEntry3, imMapEntry5, imMapEntry6, imMapEntry);
				}
				return new Leaf5(imMapEntry2, imMapEntry4, imMapEntry5, imMapEntry6, imMapEntry);
			}
			return new Leaf5(imMapEntry3, imMapEntry4, imMapEntry5, imMapEntry6, imMapEntry);
		}
	}

	internal sealed class Leaf5Plus1Plus1 : ImMap<V>
	{
		public readonly ImMapEntry<V> Plus;

		public readonly Leaf5Plus1 L;

		public Leaf5Plus1Plus1(ImMapEntry<V> plus, Leaf5Plus1 l)
		{
			Plus = plus;
			L = l;
		}

		public sealed override int Count()
		{
			return 7;
		}

		public override string ToString()
		{
			return "{L511:{P:" + Plus?.ToString() + ",L:" + L?.ToString() + "}}";
		}

		internal sealed override ImMapEntry<V> GetMinHashEntryOrDefault()
		{
			ImMapEntry<V> plus = Plus;
			ImMapEntry<V> plus2 = L.Plus;
			ImMapEntry<V> entry = L.L.Entry0;
			if (plus.Hash >= plus2.Hash)
			{
				if (plus2.Hash >= entry.Hash)
				{
					return entry;
				}
				return plus2;
			}
			if (plus.Hash >= entry.Hash)
			{
				return entry;
			}
			return plus;
		}

		internal sealed override ImMapEntry<V> GetMaxHashEntryOrDefault()
		{
			ImMapEntry<V> plus = Plus;
			ImMapEntry<V> plus2 = L.Plus;
			ImMapEntry<V> entry = L.L.Entry4;
			if (plus.Hash <= plus2.Hash)
			{
				if (plus2.Hash <= entry.Hash)
				{
					return entry;
				}
				return plus2;
			}
			if (plus.Hash <= entry.Hash)
			{
				return entry;
			}
			return plus;
		}

		internal override ImMapEntry<V> GetEntryOrNull(int hash)
		{
			if (hash == Plus.Hash)
			{
				return Plus;
			}
			if (hash == L.Plus.Hash)
			{
				return L.Plus;
			}
			Leaf5 l = L.L;
			if (hash != l.Entry0.Hash)
			{
				if (hash != l.Entry1.Hash)
				{
					if (hash != l.Entry2.Hash)
					{
						if (hash != l.Entry3.Hash)
						{
							if (hash != l.Entry4.Hash)
							{
								return null;
							}
							return l.Entry4;
						}
						return l.Entry3;
					}
					return l.Entry2;
				}
				return l.Entry1;
			}
			return l.Entry0;
		}

		internal override ImMap<V> AddOrGetEntry(int hash, ImMapEntry<V> entry)
		{
			ImMap<V> splitRight = null;
			ImMap<V> imMap = AddOrGetEntry(hash, ref entry, ref splitRight);
			if (splitRight != null)
			{
				return new Branch2(imMap, entry, splitRight);
			}
			return imMap;
		}

		internal ImMap<V> AddOrGetEntry(int hash, ref ImMapEntry<V> entry, ref ImMap<V> splitRight)
		{
			ImMapEntry<V> imMapEntry = Plus;
			int hash2 = imMapEntry.Hash;
			if (hash2 == hash)
			{
				return imMapEntry;
			}
			ImMapEntry<V> imMapEntry2 = L.Plus;
			int hash3 = imMapEntry2.Hash;
			if (hash3 == hash)
			{
				return imMapEntry2;
			}
			Leaf5 l = L.L;
			ImMapEntry<V> imMapEntry3 = l.Entry0;
			ImMapEntry<V> imMapEntry4 = l.Entry1;
			ImMapEntry<V> imMapEntry5 = l.Entry2;
			ImMapEntry<V> imMapEntry6 = l.Entry3;
			ImMapEntry<V> imMapEntry7 = l.Entry4;
			if (hash == imMapEntry3.Hash)
			{
				return imMapEntry3;
			}
			if (hash == imMapEntry4.Hash)
			{
				return imMapEntry4;
			}
			if (hash == imMapEntry5.Hash)
			{
				return imMapEntry5;
			}
			if (hash == imMapEntry6.Hash)
			{
				return imMapEntry6;
			}
			if (hash == imMapEntry7.Hash)
			{
				return imMapEntry7;
			}
			bool flag = hash > imMapEntry7.Hash && hash2 > imMapEntry7.Hash && hash3 > imMapEntry7.Hash;
			bool flag2 = !flag && hash < imMapEntry3.Hash && hash2 < imMapEntry3.Hash && hash3 < imMapEntry3.Hash;
			ImMapEntry<V> imMapEntry8 = null;
			if (hash3 < imMapEntry7.Hash)
			{
				imMapEntry8 = imMapEntry7;
				imMapEntry7 = imMapEntry2;
				imMapEntry2 = imMapEntry8;
				if (hash3 < imMapEntry6.Hash)
				{
					imMapEntry8 = imMapEntry6;
					imMapEntry6 = imMapEntry7;
					imMapEntry7 = imMapEntry8;
					if (hash3 < imMapEntry5.Hash)
					{
						imMapEntry8 = imMapEntry5;
						imMapEntry5 = imMapEntry6;
						imMapEntry6 = imMapEntry8;
						if (hash3 < imMapEntry4.Hash)
						{
							imMapEntry8 = imMapEntry4;
							imMapEntry4 = imMapEntry5;
							imMapEntry5 = imMapEntry8;
							if (hash3 < imMapEntry3.Hash)
							{
								imMapEntry8 = imMapEntry3;
								imMapEntry3 = imMapEntry4;
								imMapEntry4 = imMapEntry8;
							}
						}
					}
				}
			}
			if (hash2 < imMapEntry2.Hash)
			{
				imMapEntry8 = imMapEntry2;
				imMapEntry2 = imMapEntry;
				imMapEntry = imMapEntry8;
				if (hash2 < imMapEntry7.Hash)
				{
					imMapEntry8 = imMapEntry7;
					imMapEntry7 = imMapEntry2;
					imMapEntry2 = imMapEntry8;
					if (hash2 < imMapEntry6.Hash)
					{
						imMapEntry8 = imMapEntry6;
						imMapEntry6 = imMapEntry7;
						imMapEntry7 = imMapEntry8;
						if (hash2 < imMapEntry5.Hash)
						{
							imMapEntry8 = imMapEntry5;
							imMapEntry5 = imMapEntry6;
							imMapEntry6 = imMapEntry8;
							if (hash2 < imMapEntry4.Hash)
							{
								imMapEntry8 = imMapEntry4;
								imMapEntry4 = imMapEntry5;
								imMapEntry5 = imMapEntry8;
								if (hash2 < imMapEntry3.Hash)
								{
									imMapEntry8 = imMapEntry3;
									imMapEntry3 = imMapEntry4;
									imMapEntry4 = imMapEntry8;
								}
							}
						}
					}
				}
			}
			ImMapEntry<V> imMapEntry9 = entry;
			if (hash < imMapEntry.Hash)
			{
				imMapEntry8 = imMapEntry;
				imMapEntry = imMapEntry9;
				imMapEntry9 = imMapEntry8;
				if (hash < imMapEntry2.Hash)
				{
					imMapEntry8 = imMapEntry2;
					imMapEntry2 = imMapEntry;
					imMapEntry = imMapEntry8;
					if (hash < imMapEntry7.Hash)
					{
						imMapEntry8 = imMapEntry7;
						imMapEntry7 = imMapEntry2;
						imMapEntry2 = imMapEntry8;
						if (hash < imMapEntry6.Hash)
						{
							imMapEntry8 = imMapEntry6;
							imMapEntry6 = imMapEntry7;
							imMapEntry7 = imMapEntry8;
							if (hash < imMapEntry5.Hash)
							{
								imMapEntry8 = imMapEntry5;
								imMapEntry5 = imMapEntry6;
								imMapEntry6 = imMapEntry8;
								if (hash < imMapEntry4.Hash)
								{
									imMapEntry8 = imMapEntry4;
									imMapEntry4 = imMapEntry5;
									imMapEntry5 = imMapEntry8;
									if (hash < imMapEntry3.Hash)
									{
										imMapEntry8 = imMapEntry3;
										imMapEntry3 = imMapEntry4;
										imMapEntry4 = imMapEntry8;
									}
								}
							}
						}
					}
				}
			}
			if (flag2)
			{
				entry = imMapEntry5;
				splitRight = l;
				return new Leaf2(imMapEntry3, imMapEntry4);
			}
			entry = imMapEntry2;
			splitRight = new Leaf2(imMapEntry, imMapEntry9);
			if (!flag)
			{
				return new Leaf5(imMapEntry3, imMapEntry4, imMapEntry5, imMapEntry6, imMapEntry7);
			}
			return l;
		}

		internal ImMap<V> AddEntry(int hash, ref ImMapEntry<V> entry, ref ImMap<V> splitRight)
		{
			Leaf5 l = L.L;
			ImMapEntry<V> imMapEntry = l.Entry0;
			ImMapEntry<V> imMapEntry2 = l.Entry1;
			ImMapEntry<V> imMapEntry3 = l.Entry2;
			ImMapEntry<V> imMapEntry4 = l.Entry3;
			ImMapEntry<V> imMapEntry5 = l.Entry4;
			ImMapEntry<V> imMapEntry6 = L.Plus;
			ImMapEntry<V> imMapEntry7 = Plus;
			ImMapEntry<V> imMapEntry8 = null;
			int hash2 = imMapEntry7.Hash;
			int hash3 = imMapEntry6.Hash;
			bool flag = hash > imMapEntry5.Hash && hash2 > imMapEntry5.Hash && hash3 > imMapEntry5.Hash;
			bool flag2 = !flag && hash < imMapEntry.Hash && hash2 < imMapEntry.Hash && hash3 < imMapEntry.Hash;
			if (hash3 < imMapEntry5.Hash)
			{
				imMapEntry8 = imMapEntry5;
				imMapEntry5 = imMapEntry6;
				imMapEntry6 = imMapEntry8;
				if (hash3 < imMapEntry4.Hash)
				{
					imMapEntry8 = imMapEntry4;
					imMapEntry4 = imMapEntry5;
					imMapEntry5 = imMapEntry8;
					if (hash3 < imMapEntry3.Hash)
					{
						imMapEntry8 = imMapEntry3;
						imMapEntry3 = imMapEntry4;
						imMapEntry4 = imMapEntry8;
						if (hash3 < imMapEntry2.Hash)
						{
							imMapEntry8 = imMapEntry2;
							imMapEntry2 = imMapEntry3;
							imMapEntry3 = imMapEntry8;
							if (hash3 < imMapEntry.Hash)
							{
								imMapEntry8 = imMapEntry;
								imMapEntry = imMapEntry2;
								imMapEntry2 = imMapEntry8;
							}
						}
					}
				}
			}
			if (hash2 < imMapEntry6.Hash)
			{
				imMapEntry8 = imMapEntry6;
				imMapEntry6 = imMapEntry7;
				imMapEntry7 = imMapEntry8;
				if (hash2 < imMapEntry5.Hash)
				{
					imMapEntry8 = imMapEntry5;
					imMapEntry5 = imMapEntry6;
					imMapEntry6 = imMapEntry8;
					if (hash2 < imMapEntry4.Hash)
					{
						imMapEntry8 = imMapEntry4;
						imMapEntry4 = imMapEntry5;
						imMapEntry5 = imMapEntry8;
						if (hash2 < imMapEntry3.Hash)
						{
							imMapEntry8 = imMapEntry3;
							imMapEntry3 = imMapEntry4;
							imMapEntry4 = imMapEntry8;
							if (hash2 < imMapEntry2.Hash)
							{
								imMapEntry8 = imMapEntry2;
								imMapEntry2 = imMapEntry3;
								imMapEntry3 = imMapEntry8;
								if (hash2 < imMapEntry.Hash)
								{
									imMapEntry8 = imMapEntry;
									imMapEntry = imMapEntry2;
									imMapEntry2 = imMapEntry8;
								}
							}
						}
					}
				}
			}
			ImMapEntry<V> imMapEntry9 = entry;
			if (hash < imMapEntry7.Hash)
			{
				imMapEntry8 = imMapEntry7;
				imMapEntry7 = imMapEntry9;
				imMapEntry9 = imMapEntry8;
				if (hash < imMapEntry6.Hash)
				{
					imMapEntry8 = imMapEntry6;
					imMapEntry6 = imMapEntry7;
					imMapEntry7 = imMapEntry8;
					if (hash < imMapEntry5.Hash)
					{
						imMapEntry8 = imMapEntry5;
						imMapEntry5 = imMapEntry6;
						imMapEntry6 = imMapEntry8;
						if (hash < imMapEntry4.Hash)
						{
							imMapEntry8 = imMapEntry4;
							imMapEntry4 = imMapEntry5;
							imMapEntry5 = imMapEntry8;
							if (hash < imMapEntry3.Hash)
							{
								imMapEntry8 = imMapEntry3;
								imMapEntry3 = imMapEntry4;
								imMapEntry4 = imMapEntry8;
								if (hash < imMapEntry2.Hash)
								{
									imMapEntry8 = imMapEntry2;
									imMapEntry2 = imMapEntry3;
									imMapEntry3 = imMapEntry8;
									if (hash < imMapEntry.Hash)
									{
										imMapEntry8 = imMapEntry;
										imMapEntry = imMapEntry2;
										imMapEntry2 = imMapEntry8;
									}
								}
							}
						}
					}
				}
			}
			if (flag2)
			{
				entry = imMapEntry3;
				splitRight = l;
				return new Leaf2(imMapEntry, imMapEntry2);
			}
			entry = imMapEntry6;
			splitRight = new Leaf2(imMapEntry7, imMapEntry9);
			if (!flag)
			{
				return new Leaf5(imMapEntry, imMapEntry2, imMapEntry3, imMapEntry4, imMapEntry5);
			}
			return l;
		}

		internal override ImMap<V> ReplaceEntry(int hash, ImMapEntry<V> oldEntry, ImMapEntry<V> newEntry)
		{
			ImMapEntry<V> plus = Plus;
			if (plus == oldEntry)
			{
				return new Leaf5Plus1Plus1(newEntry, L);
			}
			ImMapEntry<V> plus2 = L.Plus;
			if (plus2 == oldEntry)
			{
				return new Leaf5Plus1Plus1(plus, new Leaf5Plus1(newEntry, L.L));
			}
			Leaf5 l = L.L;
			ImMapEntry<V> entry = l.Entry0;
			ImMapEntry<V> entry2 = l.Entry1;
			ImMapEntry<V> entry3 = l.Entry2;
			ImMapEntry<V> entry4 = l.Entry3;
			ImMapEntry<V> entry5 = l.Entry4;
			if (oldEntry != entry)
			{
				if (oldEntry != entry2)
				{
					if (oldEntry != entry3)
					{
						if (oldEntry != entry4)
						{
							return new Leaf5Plus1Plus1(plus, new Leaf5Plus1(plus2, new Leaf5(entry, entry2, entry3, entry4, newEntry)));
						}
						return new Leaf5Plus1Plus1(plus, new Leaf5Plus1(plus2, new Leaf5(entry, entry2, entry3, newEntry, entry5)));
					}
					return new Leaf5Plus1Plus1(plus, new Leaf5Plus1(plus2, new Leaf5(entry, entry2, newEntry, entry4, entry5)));
				}
				return new Leaf5Plus1Plus1(plus, new Leaf5Plus1(plus2, new Leaf5(entry, newEntry, entry3, entry4, entry5)));
			}
			return new Leaf5Plus1Plus1(plus, new Leaf5Plus1(plus2, new Leaf5(newEntry, entry2, entry3, entry4, entry5)));
		}

		internal ImMap<V> RemoveMinHashEntryAndAddNewEntry(ImMapEntry<V> minEntry, ImMapEntry<V> newEntry)
		{
			ImMapEntry<V> plus = Plus;
			if (plus == minEntry)
			{
				return new Leaf5Plus1Plus1(newEntry, L);
			}
			ImMapEntry<V> plus2 = L.Plus;
			if (plus2 == minEntry)
			{
				return new Leaf5Plus1Plus1(plus, new Leaf5Plus1(newEntry, L.L));
			}
			Leaf5 l = L.L;
			ImMapEntry<V> entry = l.Entry1;
			ImMapEntry<V> entry2 = l.Entry2;
			ImMapEntry<V> entry3 = l.Entry3;
			ImMapEntry<V> entry4 = l.Entry4;
			int hash = newEntry.Hash;
			l = ((hash < entry.Hash) ? new Leaf5(newEntry, entry, entry2, entry3, entry4) : ((hash < entry2.Hash) ? new Leaf5(entry, newEntry, entry2, entry3, entry4) : ((hash < entry3.Hash) ? new Leaf5(entry, entry2, newEntry, entry3, entry4) : ((hash < entry4.Hash) ? new Leaf5(entry, entry2, entry3, newEntry, entry4) : new Leaf5(entry, entry2, entry3, entry4, newEntry)))));
			return new Leaf5Plus1Plus1(plus, new Leaf5Plus1(plus2, l));
		}

		internal ImMap<V> RemoveMaxHashEntryAndAddNewEntry(ImMapEntry<V> maxEntry, ImMapEntry<V> newEntry)
		{
			ImMapEntry<V> plus = Plus;
			if (plus == maxEntry)
			{
				return new Leaf5Plus1Plus1(newEntry, L);
			}
			ImMapEntry<V> plus2 = L.Plus;
			if (plus2 == maxEntry)
			{
				return new Leaf5Plus1Plus1(plus, new Leaf5Plus1(newEntry, L.L));
			}
			Leaf5 l = L.L;
			ImMapEntry<V> entry = l.Entry0;
			ImMapEntry<V> entry2 = l.Entry1;
			ImMapEntry<V> entry3 = l.Entry2;
			ImMapEntry<V> entry4 = l.Entry3;
			int hash = newEntry.Hash;
			l = ((hash < entry.Hash) ? new Leaf5(newEntry, entry, entry2, entry3, entry4) : ((hash < entry2.Hash) ? new Leaf5(entry, newEntry, entry2, entry3, entry4) : ((hash < entry3.Hash) ? new Leaf5(entry, entry2, newEntry, entry3, entry4) : ((hash < entry4.Hash) ? new Leaf5(entry, entry2, entry3, newEntry, entry4) : new Leaf5(entry, entry2, entry3, entry4, newEntry)))));
			return new Leaf5Plus1Plus1(plus, new Leaf5Plus1(plus2, l));
		}

		internal override ImMap<V> RemoveEntry(ImMapEntry<V> removedEntry)
		{
			ImMapEntry<V> imMapEntry = Plus;
			if (imMapEntry == removedEntry)
			{
				return L;
			}
			ImMapEntry<V> imMapEntry2 = L.Plus;
			if (imMapEntry2 == removedEntry)
			{
				return new Leaf5Plus1(imMapEntry, L.L);
			}
			Leaf5 l = L.L;
			ImMapEntry<V> imMapEntry3 = l.Entry0;
			ImMapEntry<V> imMapEntry4 = l.Entry1;
			ImMapEntry<V> imMapEntry5 = l.Entry2;
			ImMapEntry<V> imMapEntry6 = l.Entry3;
			ImMapEntry<V> imMapEntry7 = l.Entry4;
			ImMapEntry<V> imMapEntry8 = null;
			int hash = imMapEntry2.Hash;
			int hash2 = imMapEntry.Hash;
			if (hash < imMapEntry7.Hash)
			{
				imMapEntry8 = imMapEntry7;
				imMapEntry7 = imMapEntry2;
				imMapEntry2 = imMapEntry8;
				if (hash < imMapEntry6.Hash)
				{
					imMapEntry8 = imMapEntry6;
					imMapEntry6 = imMapEntry7;
					imMapEntry7 = imMapEntry8;
					if (hash < imMapEntry5.Hash)
					{
						imMapEntry8 = imMapEntry5;
						imMapEntry5 = imMapEntry6;
						imMapEntry6 = imMapEntry8;
						if (hash < imMapEntry4.Hash)
						{
							imMapEntry8 = imMapEntry4;
							imMapEntry4 = imMapEntry5;
							imMapEntry5 = imMapEntry8;
							if (hash < imMapEntry3.Hash)
							{
								imMapEntry8 = imMapEntry3;
								imMapEntry3 = imMapEntry4;
								imMapEntry4 = imMapEntry8;
							}
						}
					}
				}
			}
			if (hash2 < imMapEntry2.Hash)
			{
				imMapEntry8 = imMapEntry2;
				imMapEntry2 = imMapEntry;
				imMapEntry = imMapEntry8;
				if (hash2 < imMapEntry7.Hash)
				{
					imMapEntry8 = imMapEntry7;
					imMapEntry7 = imMapEntry2;
					imMapEntry2 = imMapEntry8;
					if (hash2 < imMapEntry6.Hash)
					{
						imMapEntry8 = imMapEntry6;
						imMapEntry6 = imMapEntry7;
						imMapEntry7 = imMapEntry8;
						if (hash2 < imMapEntry5.Hash)
						{
							imMapEntry8 = imMapEntry5;
							imMapEntry5 = imMapEntry6;
							imMapEntry6 = imMapEntry8;
							if (hash2 < imMapEntry4.Hash)
							{
								imMapEntry8 = imMapEntry4;
								imMapEntry4 = imMapEntry5;
								imMapEntry5 = imMapEntry8;
								if (hash2 < imMapEntry3.Hash)
								{
									imMapEntry8 = imMapEntry3;
									imMapEntry3 = imMapEntry4;
									imMapEntry4 = imMapEntry8;
								}
							}
						}
					}
				}
			}
			if (removedEntry != imMapEntry3)
			{
				if (removedEntry != imMapEntry4)
				{
					if (removedEntry != imMapEntry5)
					{
						if (removedEntry != imMapEntry6)
						{
							if (removedEntry != imMapEntry7)
							{
								if (removedEntry != imMapEntry2)
								{
									return new Leaf5Plus1(imMapEntry2, new Leaf5(imMapEntry3, imMapEntry4, imMapEntry5, imMapEntry6, imMapEntry7));
								}
								return new Leaf5Plus1(imMapEntry, new Leaf5(imMapEntry3, imMapEntry4, imMapEntry5, imMapEntry6, imMapEntry7));
							}
							return new Leaf5Plus1(imMapEntry, new Leaf5(imMapEntry3, imMapEntry4, imMapEntry5, imMapEntry6, imMapEntry2));
						}
						return new Leaf5Plus1(imMapEntry, new Leaf5(imMapEntry3, imMapEntry4, imMapEntry5, imMapEntry7, imMapEntry2));
					}
					return new Leaf5Plus1(imMapEntry, new Leaf5(imMapEntry3, imMapEntry4, imMapEntry6, imMapEntry7, imMapEntry2));
				}
				return new Leaf5Plus1(imMapEntry, new Leaf5(imMapEntry3, imMapEntry5, imMapEntry6, imMapEntry7, imMapEntry2));
			}
			return new Leaf5Plus1(imMapEntry, new Leaf5(imMapEntry4, imMapEntry5, imMapEntry6, imMapEntry7, imMapEntry2));
		}
	}

	internal sealed class Branch2 : ImMap<V>
	{
		public readonly ImMapEntry<V> MidEntry;

		public readonly ImMap<V> Left;

		public readonly ImMap<V> Right;

		public override bool IsBranch => true;

		public Branch2(ImMap<V> left, ImMapEntry<V> entry, ImMap<V> right)
		{
			MidEntry = entry;
			Left = left;
			Right = right;
		}

		public override int Count()
		{
			return 1 + Left.Count() + Right.Count();
		}

		public override string ToString()
		{
			return "{B2:{E:" + MidEntry?.ToString() + ",L:" + Left?.ToString() + ",R:" + Right?.ToString() + "}}";
		}

		internal override ImMapEntry<V> GetMinHashEntryOrDefault()
		{
			return Left.GetMinHashEntryOrDefault();
		}

		internal override ImMapEntry<V> GetMaxHashEntryOrDefault()
		{
			return Right.GetMaxHashEntryOrDefault();
		}

		internal override ImMapEntry<V> GetEntryOrNull(int hash)
		{
			int hash2 = MidEntry.Hash;
			if (hash <= hash2)
			{
				if (hash >= hash2)
				{
					return MidEntry;
				}
				return Left.GetEntryOrNull(hash);
			}
			return Right.GetEntryOrNull(hash);
		}

		internal override ImMap<V> AddOrGetEntry(int hash, ImMapEntry<V> entry)
		{
			ImMapEntry<V> midEntry = MidEntry;
			ImMap<V> imMap = null;
			if (hash > midEntry.Hash)
			{
				ImMap<V> right = Right;
				if (right is Leaf5Plus1Plus1 leaf5Plus1Plus)
				{
					if (!(Left is Leaf5Plus1Plus1))
					{
						ImMapEntry<V> entryOrNull = leaf5Plus1Plus.GetEntryOrNull(hash);
						if (entryOrNull != null)
						{
							return entryOrNull;
						}
						return new Branch2Plus1(entry, this);
					}
					ImMap<V> splitRight = null;
					imMap = leaf5Plus1Plus.AddOrGetEntry(hash, ref entry, ref splitRight);
					if (splitRight == null)
					{
						return imMap;
					}
					return new Branch3(Left, midEntry, imMap, entry, splitRight);
				}
				if (right is Branch3 branch)
				{
					ImMap<V> splitRight2 = null;
					imMap = branch.AddOrGetEntry(hash, ref entry, ref splitRight2);
					if (splitRight2 != null)
					{
						return new Branch3(Left, midEntry, imMap, entry, splitRight2);
					}
				}
				else
				{
					imMap = right.AddOrGetEntry(hash, entry);
				}
				if (!(imMap is ImMapEntry<V>))
				{
					return new Branch2(Left, midEntry, imMap);
				}
				return imMap;
			}
			if (hash < midEntry.Hash)
			{
				ImMap<V> left = Left;
				if (left is Leaf5Plus1Plus1 leaf5Plus1Plus2)
				{
					if (!(Right is Leaf5Plus1Plus1))
					{
						ImMapEntry<V> entryOrNull2 = leaf5Plus1Plus2.GetEntryOrNull(hash);
						if (entryOrNull2 != null)
						{
							return entryOrNull2;
						}
						return new Branch2Plus1(entry, this);
					}
					ImMap<V> splitRight3 = null;
					imMap = leaf5Plus1Plus2.AddOrGetEntry(hash, ref entry, ref splitRight3);
					if (splitRight3 == null)
					{
						return imMap;
					}
					return new Branch3(imMap, entry, splitRight3, midEntry, Right);
				}
				if (left is Branch3 branch2)
				{
					ImMap<V> splitRight4 = null;
					imMap = branch2.AddOrGetEntry(hash, ref entry, ref splitRight4);
					if (splitRight4 != null)
					{
						return new Branch3(imMap, entry, splitRight4, midEntry, Right);
					}
				}
				else
				{
					imMap = left.AddOrGetEntry(hash, entry);
				}
				if (!(imMap is ImMapEntry<V>))
				{
					return new Branch2(imMap, midEntry, Right);
				}
				return imMap;
			}
			return midEntry;
		}

		internal override ImMap<V> ReplaceEntry(int hash, ImMapEntry<V> oldEntry, ImMapEntry<V> newEntry)
		{
			int hash2 = MidEntry.Hash;
			if (hash <= hash2)
			{
				if (hash >= hash2)
				{
					return new Branch2(Left, newEntry, Right);
				}
				return new Branch2(Left.ReplaceEntry(hash, oldEntry, newEntry), MidEntry, Right);
			}
			return new Branch2(Left, MidEntry, Right.ReplaceEntry(hash, oldEntry, newEntry));
		}

		internal override ImMap<V> RemoveEntry(ImMapEntry<V> removedEntry)
		{
			ImMapEntry<V> imMapEntry = MidEntry;
			if (removedEntry.Hash > imMapEntry.Hash)
			{
				if (Right is ImMapEntry<V>)
				{
					if (!(Left is Leaf5Plus1Plus1))
					{
						return Left.AddOrGetEntry(imMapEntry.Hash, imMapEntry);
					}
					removedEntry = Left.GetMaxHashEntryOrDefault();
					return new Branch2(Left.RemoveEntry(removedEntry), removedEntry, imMapEntry);
				}
				ImMap<V> imMap = Right.RemoveEntry(removedEntry);
				if (Right is Branch2 && !(imMap is Branch2))
				{
					ImMap<V> left = Left;
					if (left is Branch3 branch)
					{
						return new Branch2(new Branch2(branch.Left, branch.Entry0, branch.Middle), branch.Entry1, new Branch2(branch.Right, imMapEntry, imMap));
					}
					if (left is Branch2Plus1 branch2Plus)
					{
						ImMapEntry<V> newMid;
						ImMap<V> newRight;
						return new Branch3(branch2Plus.ToSplitBranch2(out newMid, out newRight), newMid, newRight, imMapEntry, imMap);
					}
					Branch2 branch2 = (Branch2)left;
					return new Branch3(branch2.Left, branch2.MidEntry, branch2.Right, imMapEntry, imMap);
				}
				return new Branch2(Left, imMapEntry, imMap);
			}
			if (removedEntry == imMapEntry)
			{
				removedEntry = (imMapEntry = Left.GetMaxHashEntryOrDefault());
			}
			ImMap<V> imMap2 = Left.RemoveEntry(removedEntry);
			if (imMap2 == Empty)
			{
				if (!(Right is Leaf5Plus1Plus1))
				{
					return Right.AddOrGetEntry(imMapEntry.Hash, imMapEntry);
				}
				removedEntry = Right.GetMinHashEntryOrDefault();
				return new Branch2(imMapEntry, removedEntry, Right.RemoveEntry(removedEntry));
			}
			if (Left is Branch2 && !(imMap2 is Branch2))
			{
				ImMap<V> right = Right;
				if (right is Branch3 branch3)
				{
					return new Branch2(new Branch2(imMap2, imMapEntry, branch3.Left), branch3.Entry0, new Branch2(branch3.Middle, branch3.Entry1, branch3.Right));
				}
				if (right is Branch2Plus1 branch2Plus2)
				{
					ImMapEntry<V> newMid2;
					ImMap<V> newRight2;
					return new Branch3(imMap2, imMapEntry, branch2Plus2.ToSplitBranch2(out newMid2, out newRight2), newMid2, newRight2);
				}
				Branch2 branch4 = (Branch2)right;
				return new Branch3(imMap2, imMapEntry, branch4.Left, branch4.MidEntry, branch4.Right);
			}
			return new Branch2(imMap2, imMapEntry, Right);
		}
	}

	internal sealed class Branch2Plus1 : ImMap<V>
	{
		public readonly ImMapEntry<V> Plus;

		public readonly Branch2 B;

		public override bool IsBranch => true;

		public Branch2Plus1(ImMapEntry<V> plus, Branch2 branch)
		{
			Plus = plus;
			B = branch;
		}

		public override int Count()
		{
			return 1 + B.Count();
		}

		public override string ToString()
		{
			return "{B21:{Plus:" + Plus?.ToString() + ",B:" + B?.ToString() + "}}";
		}

		internal ImMap<V> ToSplitBranch2(out ImMapEntry<V> newMid, out ImMap<V> newRight)
		{
			Branch2 b = B;
			ImMapEntry<V> midEntry = b.MidEntry;
			if (b.Left is Leaf5Plus1Plus1 leaf5Plus1Plus)
			{
				newRight = b.Right.AddOrGetEntry(midEntry.Hash, midEntry);
				newMid = leaf5Plus1Plus.GetMaxHashEntryOrDefault();
				if (newMid.Hash > Plus.Hash)
				{
					return leaf5Plus1Plus.RemoveMaxHashEntryAndAddNewEntry(newMid, Plus);
				}
				newMid = Plus;
				return leaf5Plus1Plus;
			}
			Leaf5Plus1Plus1 leaf5Plus1Plus2 = (Leaf5Plus1Plus1)(newRight = (Leaf5Plus1Plus1)b.Right);
			newMid = leaf5Plus1Plus2.GetMinHashEntryOrDefault();
			if (newMid.Hash < Plus.Hash)
			{
				newRight = leaf5Plus1Plus2.RemoveMinHashEntryAndAddNewEntry(newMid, Plus);
			}
			else
			{
				newMid = Plus;
			}
			return b.Left.AddOrGetEntry(midEntry.Hash, midEntry);
		}

		internal override ImMapEntry<V> GetMinHashEntryOrDefault()
		{
			ImMapEntry<V> minHashEntryOrDefault = B.Left.GetMinHashEntryOrDefault();
			if (minHashEntryOrDefault.Hash >= Plus.Hash)
			{
				return Plus;
			}
			return minHashEntryOrDefault;
		}

		internal sealed override ImMapEntry<V> GetMaxHashEntryOrDefault()
		{
			ImMapEntry<V> maxHashEntryOrDefault = B.Right.GetMaxHashEntryOrDefault();
			if (maxHashEntryOrDefault.Hash <= Plus.Hash)
			{
				return Plus;
			}
			return maxHashEntryOrDefault;
		}

		internal override ImMapEntry<V> GetEntryOrNull(int hash)
		{
			if (Plus.Hash == hash)
			{
				return Plus;
			}
			int hash2 = B.MidEntry.Hash;
			if (hash <= hash2)
			{
				if (hash >= hash2)
				{
					return B.MidEntry;
				}
				return B.Left.GetEntryOrNull(hash);
			}
			return B.Right.GetEntryOrNull(hash);
		}

		internal override ImMap<V> AddOrGetEntry(int hash, ImMapEntry<V> entry)
		{
			int hash2 = Plus.Hash;
			if (hash2 == hash)
			{
				return Plus;
			}
			Branch2 b = B;
			ImMapEntry<V> midEntry = b.MidEntry;
			ImMap<V> imMap = null;
			if (hash > midEntry.Hash)
			{
				ImMap<V> right = b.Right;
				ImMap<V> splitRight = null;
				if (right is Leaf5Plus1Plus1 leaf5Plus1Plus)
				{
					imMap = leaf5Plus1Plus.AddOrGetEntry(hash, ref entry, ref splitRight);
					if (splitRight == null)
					{
						return imMap;
					}
					if (hash2 <= entry.Hash)
					{
						return new Branch3(b.Left, midEntry, (imMap is Leaf5 l) ? ((ImMap<V>)new Leaf5Plus1(Plus, l)) : ((ImMap<V>)new Leaf2Plus1(Plus, (Leaf2)imMap)), entry, splitRight);
					}
					return new Branch3(b.Left, midEntry, imMap, entry, (splitRight is Leaf2 leaf) ? ((ImMap<V>)new Leaf2Plus1(Plus, leaf)) : ((ImMap<V>)new Leaf5Plus1(Plus, (Leaf5)splitRight)));
				}
				imMap = right.AddOrGetEntry(hash, entry);
				if (imMap is ImMapEntry<V>)
				{
					return imMap;
				}
				entry = Plus;
				ImMap<V> left = ((Leaf5Plus1Plus1)b.Left).AddEntry(hash2, ref entry, ref splitRight);
				return new Branch3(left, entry, splitRight, midEntry, imMap);
			}
			if (hash < midEntry.Hash)
			{
				ImMap<V> left2 = b.Left;
				ImMap<V> splitRight2 = null;
				if (left2 is Leaf5Plus1Plus1 leaf5Plus1Plus2)
				{
					imMap = leaf5Plus1Plus2.AddOrGetEntry(hash, ref entry, ref splitRight2);
					if (splitRight2 == null)
					{
						return imMap;
					}
					if (hash2 >= entry.Hash)
					{
						return new Branch3(imMap, entry, (splitRight2 is Leaf2 leaf2) ? ((ImMap<V>)new Leaf2Plus1(Plus, leaf2)) : ((ImMap<V>)new Leaf5Plus1(Plus, (Leaf5)splitRight2)), midEntry, b.Right);
					}
					return new Branch3((imMap is Leaf5 l2) ? ((ImMap<V>)new Leaf5Plus1(Plus, l2)) : ((ImMap<V>)new Leaf2Plus1(Plus, (Leaf2)imMap)), entry, splitRight2, midEntry, b.Right);
				}
				imMap = left2.AddOrGetEntry(hash, entry);
				if (imMap is ImMapEntry<V>)
				{
					return imMap;
				}
				entry = Plus;
				ImMap<V> middle = ((Leaf5Plus1Plus1)b.Right).AddEntry(hash2, ref entry, ref splitRight2);
				return new Branch3(imMap, midEntry, middle, entry, splitRight2);
			}
			return midEntry;
		}

		internal override ImMap<V> ReplaceEntry(int hash, ImMapEntry<V> oldEntry, ImMapEntry<V> newEntry)
		{
			if (oldEntry != Plus)
			{
				return new Branch2Plus1(Plus, (Branch2)B.ReplaceEntry(hash, oldEntry, newEntry));
			}
			return new Branch2Plus1(newEntry, B);
		}

		internal override ImMap<V> RemoveEntry(ImMapEntry<V> removedEntry)
		{
			if (removedEntry == Plus)
			{
				return B;
			}
			Branch2 b = B;
			ImMapEntry<V> plus = Plus;
			ImMapEntry<V> midEntry = b.MidEntry;
			if (removedEntry == midEntry)
			{
				if (b.Right is Leaf5Plus1Plus1 leaf5Plus1Plus)
				{
					ImMapEntry<V> minHashEntryOrDefault = leaf5Plus1Plus.GetMinHashEntryOrDefault();
					if (minHashEntryOrDefault.Hash <= plus.Hash)
					{
						return new Branch2(b.Left, minHashEntryOrDefault, leaf5Plus1Plus.RemoveMinHashEntryAndAddNewEntry(minHashEntryOrDefault, plus));
					}
					return new Branch2(b.Left, plus, leaf5Plus1Plus);
				}
				Leaf5Plus1Plus1 leaf5Plus1Plus2 = (Leaf5Plus1Plus1)b.Left;
				ImMapEntry<V> maxHashEntryOrDefault = leaf5Plus1Plus2.GetMaxHashEntryOrDefault();
				if (maxHashEntryOrDefault.Hash >= plus.Hash)
				{
					return new Branch2(leaf5Plus1Plus2.RemoveMaxHashEntryAndAddNewEntry(maxHashEntryOrDefault, plus), maxHashEntryOrDefault, b.Right);
				}
				return new Branch2(leaf5Plus1Plus2, plus, b.Right);
			}
			if (removedEntry.Hash > midEntry.Hash)
			{
				if (b.Right is Leaf5Plus1Plus1 leaf5Plus1Plus3)
				{
					return new Branch2(b.Left, midEntry, leaf5Plus1Plus3.RemoveEntry(removedEntry).AddOrGetEntry(plus.Hash, plus));
				}
				ImMap<V> imMap = b.Right.RemoveEntry(removedEntry);
				if (imMap == Empty)
				{
					Leaf5Plus1Plus1 leaf5Plus1Plus4 = (Leaf5Plus1Plus1)b.Left;
					ImMapEntry<V> maxHashEntryOrDefault2 = leaf5Plus1Plus4.GetMaxHashEntryOrDefault();
					if (maxHashEntryOrDefault2.Hash >= plus.Hash)
					{
						return new Branch2(leaf5Plus1Plus4.RemoveEntry(maxHashEntryOrDefault2), plus, maxHashEntryOrDefault2);
					}
					return new Branch2(leaf5Plus1Plus4.RemoveEntry(maxHashEntryOrDefault2), maxHashEntryOrDefault2, plus);
				}
				return new Branch2Plus1(plus, new Branch2(b.Left, midEntry, imMap));
			}
			if (b.Left is Leaf5Plus1Plus1 leaf5Plus1Plus5)
			{
				return new Branch2(leaf5Plus1Plus5.RemoveEntry(removedEntry).AddOrGetEntry(plus.Hash, plus), midEntry, b.Right);
			}
			ImMap<V> imMap2 = b.Left.RemoveEntry(removedEntry);
			if (imMap2 == Empty)
			{
				Leaf5Plus1Plus1 leaf5Plus1Plus6 = (Leaf5Plus1Plus1)b.Right;
				ImMapEntry<V> minHashEntryOrDefault2 = leaf5Plus1Plus6.GetMinHashEntryOrDefault();
				if (minHashEntryOrDefault2.Hash <= plus.Hash)
				{
					return new Branch2(minHashEntryOrDefault2, plus, leaf5Plus1Plus6.RemoveEntry(minHashEntryOrDefault2));
				}
				return new Branch2(plus, minHashEntryOrDefault2, leaf5Plus1Plus6.RemoveEntry(minHashEntryOrDefault2));
			}
			return new Branch2Plus1(plus, new Branch2(imMap2, midEntry, b.Right));
		}
	}

	internal sealed class Branch3 : ImMap<V>
	{
		public readonly ImMapEntry<V> Entry0;

		public readonly ImMapEntry<V> Entry1;

		public readonly ImMap<V> Left;

		public readonly ImMap<V> Middle;

		public readonly ImMap<V> Right;

		public override bool IsBranch => true;

		public Branch3(ImMap<V> left, ImMapEntry<V> e0, ImMap<V> middle, ImMapEntry<V> e1, ImMap<V> right)
		{
			Left = left;
			Entry0 = e0;
			Middle = middle;
			Entry1 = e1;
			Right = right;
		}

		public override int Count()
		{
			return 2 + Left.Count() + Middle.Count() + Right.Count();
		}

		public override string ToString()
		{
			return "{B3:{E0:" + Entry0?.ToString() + ",E1:" + Entry0?.ToString() + ",L:" + Left?.ToString() + ",M:" + Middle?.ToString() + ",R:" + Right?.ToString() + "}}";
		}

		internal override ImMapEntry<V> GetMinHashEntryOrDefault()
		{
			return Left.GetMinHashEntryOrDefault();
		}

		internal override ImMapEntry<V> GetMaxHashEntryOrDefault()
		{
			return Right.GetMaxHashEntryOrDefault();
		}

		internal override ImMapEntry<V> GetEntryOrNull(int hash)
		{
			int hash2 = Entry1.Hash;
			if (hash > hash2)
			{
				return Right.GetEntryOrNull(hash);
			}
			int hash3 = Entry0.Hash;
			if (hash < hash3)
			{
				return Left.GetEntryOrNull(hash);
			}
			if (hash3 == hash)
			{
				return Entry0;
			}
			if (hash2 == hash)
			{
				return Entry1;
			}
			return Middle.GetEntryOrNull(hash);
		}

		internal override ImMap<V> AddOrGetEntry(int hash, ImMapEntry<V> entry)
		{
			int hash2 = Entry1.Hash;
			if (hash > hash2)
			{
				ImMap<V> right = Right;
				ImMap<V> imMap = right.AddOrGetEntry(hash, entry);
				if (imMap is ImMapEntry<V>)
				{
					return imMap;
				}
				if ((right is Branch3 && imMap is Branch2) || right is Leaf5Plus1Plus1)
				{
					return new Branch2(new Branch2(Left, Entry0, Middle), Entry1, imMap);
				}
				return new Branch3(Left, Entry0, Middle, Entry1, imMap);
			}
			int hash3 = Entry0.Hash;
			if (hash < hash3)
			{
				ImMap<V> left = Left;
				ImMap<V> imMap2 = left.AddOrGetEntry(hash, entry);
				if (imMap2 is ImMapEntry<V>)
				{
					return imMap2;
				}
				if ((left is Branch3 && imMap2 is Branch2) || left is Leaf5Plus1Plus1)
				{
					return new Branch2(imMap2, Entry0, new Branch2(Middle, Entry1, Right));
				}
				return new Branch3(imMap2, Entry0, Middle, Entry1, Right);
			}
			if (hash > hash3 && hash < hash2)
			{
				ImMap<V> middle = Middle;
				ImMap<V> imMap3 = null;
				if (middle is Leaf5Plus1Plus1 leaf5Plus1Plus)
				{
					ImMap<V> splitRight = null;
					imMap3 = leaf5Plus1Plus.AddOrGetEntry(hash, ref entry, ref splitRight);
					if (splitRight != null)
					{
						return new Branch2(new Branch2(Left, Entry0, imMap3), entry, new Branch2(splitRight, Entry1, Right));
					}
					return imMap3;
				}
				if (middle is Branch3 branch)
				{
					ImMap<V> splitRight2 = null;
					imMap3 = branch.AddOrGetEntry(hash, ref entry, ref splitRight2);
					if (splitRight2 != null)
					{
						return new Branch2(new Branch2(Left, Entry0, imMap3), entry, new Branch2(splitRight2, Entry1, Right));
					}
				}
				else
				{
					imMap3 = middle.AddOrGetEntry(hash, entry);
				}
				if (!(imMap3 is ImMapEntry<V>))
				{
					return new Branch3(Left, Entry0, imMap3, Entry1, Right);
				}
				return imMap3;
			}
			if (hash != hash3)
			{
				return Entry1;
			}
			return Entry0;
		}

		internal ImMap<V> AddOrGetEntry(int hash, ref ImMapEntry<V> entry, ref ImMap<V> splitRight)
		{
			int hash2 = Entry1.Hash;
			if (hash > hash2)
			{
				ImMap<V> right = Right;
				ImMap<V> imMap = right.AddOrGetEntry(hash, entry);
				if (imMap is ImMapEntry<V>)
				{
					return imMap;
				}
				if ((right is Branch3 && imMap is Branch2) || right is Leaf5Plus1Plus1)
				{
					entry = Entry1;
					splitRight = imMap;
					return new Branch2(Left, Entry0, Middle);
				}
				return new Branch3(Left, Entry0, Middle, Entry1, imMap);
			}
			int hash3 = Entry0.Hash;
			if (hash < hash3)
			{
				ImMap<V> left = Left;
				ImMap<V> imMap2 = left.AddOrGetEntry(hash, entry);
				if (imMap2 is ImMapEntry<V>)
				{
					return imMap2;
				}
				if ((left is Branch3 && imMap2 is Branch2) || left is Leaf5Plus1Plus1)
				{
					entry = Entry0;
					splitRight = new Branch2(Middle, Entry1, Right);
					return imMap2;
				}
				return new Branch3(imMap2, Entry0, Middle, Entry1, Right);
			}
			if (hash > hash3 && hash < hash2)
			{
				ImMap<V> middle = Middle;
				ImMap<V> imMap3 = null;
				ImMap<V> splitRight2 = null;
				if (middle is Leaf5Plus1Plus1 leaf5Plus1Plus)
				{
					imMap3 = leaf5Plus1Plus.AddOrGetEntry(hash, ref entry, ref splitRight2);
					if (splitRight2 == null)
					{
						return imMap3;
					}
					splitRight = new Branch2(splitRight2, Entry1, Right);
					return new Branch2(Left, Entry0, imMap3);
				}
				if (middle is Branch3 branch)
				{
					imMap3 = branch.AddOrGetEntry(hash, ref entry, ref splitRight2);
					if (splitRight2 != null)
					{
						splitRight = new Branch2(splitRight2, Entry1, Right);
						return new Branch2(Left, Entry0, imMap3);
					}
				}
				else
				{
					imMap3 = middle.AddOrGetEntry(hash, entry);
				}
				if (!(imMap3 is ImMapEntry<V>))
				{
					return new Branch3(Left, Entry0, imMap3, Entry1, Right);
				}
				return imMap3;
			}
			if (hash != hash3)
			{
				return Entry1;
			}
			return Entry0;
		}

		internal override ImMap<V> ReplaceEntry(int hash, ImMapEntry<V> oldEntry, ImMapEntry<V> newEntry)
		{
			int hash2 = Entry0.Hash;
			int hash3 = Entry1.Hash;
			if (hash <= hash3)
			{
				if (hash >= hash2)
				{
					if (hash <= hash2 || hash >= hash3)
					{
						if (hash != hash2)
						{
							return new Branch3(Left, Entry0, Middle, newEntry, Right);
						}
						return new Branch3(Left, newEntry, Middle, Entry1, Right);
					}
					return new Branch3(Left, Entry0, Middle.ReplaceEntry(hash, oldEntry, newEntry), Entry1, Right);
				}
				return new Branch3(Left.ReplaceEntry(hash, oldEntry, newEntry), Entry0, Middle, Entry1, Right);
			}
			return new Branch3(Left, Entry0, Middle, Entry1, Right.ReplaceEntry(hash, oldEntry, newEntry));
		}

		internal override ImMap<V> RemoveEntry(ImMapEntry<V> removedEntry)
		{
			ImMapEntry<V> imMapEntry = Entry0;
			ImMapEntry<V> imMapEntry2 = Entry1;
			ImMap<V> middle = Middle;
			ImMap<V> right = Right;
			if (removedEntry == imMapEntry)
			{
				removedEntry = (imMapEntry = Left.GetMaxHashEntryOrDefault());
			}
			if (removedEntry.Hash <= imMapEntry.Hash)
			{
				ImMap<V> imMap = Left.RemoveEntry(removedEntry);
				if (imMap == Empty)
				{
					if (!(middle is Leaf5Plus1Plus1))
					{
						return new Branch2(middle.AddOrGetEntry(imMapEntry.Hash, imMapEntry), imMapEntry2, right);
					}
					return new Branch3(imMapEntry, removedEntry = middle.GetMinHashEntryOrDefault(), middle.RemoveEntry(removedEntry), imMapEntry2, right);
				}
				if (Left is Branch2 && !(imMap is Branch2))
				{
					if (middle is Branch3 branch)
					{
						return new Branch3(new Branch2(imMap, imMapEntry, branch.Left), branch.Entry0, new Branch2(branch.Middle, branch.Entry1, branch.Right), imMapEntry2, right);
					}
					if (middle is Branch2Plus1 branch2Plus)
					{
						ImMapEntry<V> newMid;
						ImMap<V> newRight;
						return new Branch2(new Branch3(imMap, imMapEntry, branch2Plus.ToSplitBranch2(out newMid, out newRight), newMid, newRight), imMapEntry2, right);
					}
					Branch2 branch2 = (Branch2)middle;
					return new Branch2(new Branch3(imMap, imMapEntry, branch2.Left, branch2.MidEntry, branch2.Right), imMapEntry2, right);
				}
				return new Branch3(imMap, imMapEntry, middle, imMapEntry2, right);
			}
			if (removedEntry == imMapEntry2)
			{
				removedEntry = (imMapEntry2 = middle.GetMaxHashEntryOrDefault());
			}
			if (removedEntry.Hash <= imMapEntry2.Hash)
			{
				ImMap<V> imMap2 = middle.RemoveEntry(removedEntry);
				if (imMap2 == Empty)
				{
					if (!(right is Leaf5Plus1Plus1))
					{
						return new Branch2(Left, imMapEntry, right.AddOrGetEntry(imMapEntry2.Hash, imMapEntry2));
					}
					return new Branch3(Left, imMapEntry, imMapEntry2, removedEntry = right.GetMinHashEntryOrDefault(), right.RemoveEntry(removedEntry));
				}
				if (middle is Branch2 && !(imMap2 is Branch2))
				{
					if (right is Branch3 branch3)
					{
						return new Branch3(Left, imMapEntry, new Branch2(imMap2, imMapEntry2, branch3.Left), branch3.Entry0, new Branch2(branch3.Middle, branch3.Entry1, branch3.Right));
					}
					if (right is Branch2Plus1 branch2Plus2)
					{
						ImMapEntry<V> newMid2;
						ImMap<V> newRight2;
						return new Branch2(Left, imMapEntry, new Branch3(imMap2, imMapEntry2, branch2Plus2.ToSplitBranch2(out newMid2, out newRight2), newMid2, newRight2));
					}
					Branch2 branch4 = (Branch2)right;
					return new Branch2(Left, imMapEntry, new Branch3(imMap2, imMapEntry2, branch4.Left, branch4.MidEntry, branch4.Right));
				}
				return new Branch3(Left, imMapEntry, imMap2, imMapEntry2, right);
			}
			ImMap<V> imMap3 = right.RemoveEntry(removedEntry);
			if (imMap3 == Empty)
			{
				if (!(middle is Leaf5Plus1Plus1))
				{
					return new Branch2(Left, imMapEntry, middle.AddOrGetEntry(imMapEntry2.Hash, imMapEntry2));
				}
				return new Branch3(Left, imMapEntry, middle.RemoveEntry(removedEntry = middle.GetMaxHashEntryOrDefault()), removedEntry, imMapEntry2);
			}
			if (right is Branch2 && !(imMap3 is Branch2))
			{
				if (middle is Branch3 branch5)
				{
					return new Branch3(Left, imMapEntry, new Branch2(branch5.Left, branch5.Entry0, branch5.Middle), branch5.Entry1, new Branch2(branch5.Right, imMapEntry2, imMap3));
				}
				if (middle is Branch2Plus1 branch2Plus3)
				{
					ImMapEntry<V> newMid3;
					ImMap<V> newRight3;
					return new Branch2(Left, imMapEntry, new Branch3(branch2Plus3.ToSplitBranch2(out newMid3, out newRight3), newMid3, newRight3, imMapEntry2, imMap3));
				}
				Branch2 branch6 = (Branch2)middle;
				return new Branch2(Left, imMapEntry, new Branch3(branch6.Left, branch6.MidEntry, branch6.Right, imMapEntry2, imMap3));
			}
			return new Branch3(Left, imMapEntry, middle, imMapEntry2, imMap3);
		}
	}

	public static readonly ImMap<V> Empty = new ImMap<V>();

	public bool IsEmpty => this == Empty;

	public virtual bool IsBranch => false;

	protected ImMap()
	{
	}

	public override string ToString()
	{
		return "{}";
	}

	public virtual int Count()
	{
		return 0;
	}

	internal virtual ImMapEntry<V> GetMinHashEntryOrDefault()
	{
		return null;
	}

	internal virtual ImMapEntry<V> GetMaxHashEntryOrDefault()
	{
		return null;
	}

	internal virtual ImMapEntry<V> GetEntryOrNull(int hash)
	{
		return null;
	}

	internal virtual ImMap<V> AddOrGetEntry(int hash, ImMapEntry<V> entry)
	{
		return entry;
	}

	internal virtual ImMap<V> ReplaceEntry(int hash, ImMapEntry<V> oldEntry, ImMapEntry<V> newEntry)
	{
		return this;
	}

	internal virtual ImMap<V> RemoveEntry(ImMapEntry<V> entry)
	{
		return this;
	}
}
public static class ImMap
{
	internal struct ImMapStack<V>
	{
		private ImMapEntry<V> e0;

		private ImMapEntry<V> e1;

		private ImMapEntry<V> e2;

		private ImMapEntry<V> e3;

		private ImMapEntry<V> e4;

		private ImMapEntry<V> e5;

		private ImMapEntry<V> e6;

		private ImMapEntry<V> e7;

		private ImMap<V> b0;

		private ImMap<V> b1;

		private ImMap<V> b2;

		private ImMap<V> b3;

		private ImMap<V> b4;

		private ImMap<V> b5;

		private ImMap<V> b6;

		private ImMap<V> b7;

		private ImMapParentStack<V> _deeper;

		private const byte _deeperStartsAtLevel = 8;

		public void Put(ushort i, ImMapEntry<V> e, ImMap<V> b)
		{
			switch (i)
			{
			case 0:
				e0 = e;
				b0 = b;
				return;
			case 1:
				e1 = e;
				b1 = b;
				return;
			case 2:
				e2 = e;
				b2 = b;
				return;
			case 3:
				e3 = e;
				b3 = b;
				return;
			case 4:
				e4 = e;
				b4 = b;
				return;
			case 5:
				e5 = e;
				b5 = b;
				return;
			case 6:
				e6 = e;
				b6 = b;
				return;
			case 7:
				e7 = e;
				b7 = b;
				return;
			}
			if (_deeper == null)
			{
				_deeper = new ImMapParentStack<V>(8);
			}
			_deeper.Put(i - 8, e, b);
		}

		public void Put(ushort i, ImMapEntry<V> e, ImMap<V> b, ImMapEntry<V> eNext, ImMap<V> bNext)
		{
			switch (i)
			{
			case 0:
				e0 = e;
				b0 = b;
				e1 = eNext;
				b1 = bNext;
				break;
			case 1:
				e1 = e;
				b1 = b;
				e2 = eNext;
				b2 = bNext;
				break;
			case 2:
				e2 = e;
				b2 = b;
				e3 = eNext;
				b3 = bNext;
				break;
			case 3:
				e3 = e;
				b3 = b;
				e4 = eNext;
				b4 = bNext;
				break;
			case 4:
				e4 = e;
				b4 = b;
				e5 = eNext;
				b5 = bNext;
				break;
			case 5:
				e5 = e;
				b5 = b;
				e6 = eNext;
				b6 = bNext;
				break;
			case 6:
				e6 = e;
				b6 = b;
				e7 = eNext;
				b7 = bNext;
				break;
			case 7:
				e7 = e;
				b7 = b;
				if (_deeper == null)
				{
					_deeper = new ImMapParentStack<V>(8);
				}
				_deeper.Put(0, eNext, bNext);
				break;
			default:
				if (_deeper == null)
				{
					_deeper = new ImMapParentStack<V>(8);
				}
				i -= 8;
				_deeper.Put(i, e, b);
				_deeper.Put(i + 1, eNext, bNext);
				break;
			}
		}

		public void Get(ushort i, ref ImMapEntry<V> e, ref ImMap<V> b)
		{
			switch (i)
			{
			case 0:
				e = e0;
				b = b0;
				break;
			case 1:
				e = e1;
				b = b1;
				break;
			case 2:
				e = e2;
				b = b2;
				break;
			case 3:
				e = e3;
				b = b3;
				break;
			case 4:
				e = e4;
				b = b4;
				break;
			case 5:
				e = e5;
				b = b5;
				break;
			case 6:
				e = e6;
				b = b6;
				break;
			case 7:
				e = e7;
				b = b7;
				break;
			default:
			{
				ref ImMapParentStack<V>.Entry reference = ref _deeper.Items[i - 8];
				e = reference.NextEntry;
				b = reference.NextBranch;
				break;
			}
			}
		}
	}

	public struct ImMapEnumerable<V> : IEnumerable<ImMapEntry<V>>, IEnumerable
	{
		private readonly ImMap<V> _map;

		public ImMapEnumerable(ImMap<V> map)
		{
			_map = map;
		}

		public ImMapEnumerator<V> GetEnumerator()
		{
			return new ImMapEnumerator<V>
			{
				_map = _map
			};
		}

		IEnumerator<ImMapEntry<V>> IEnumerable<ImMapEntry<V>>.GetEnumerator()
		{
			return new ImMapEnumerator<V>
			{
				_map = _map
			};
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new ImMapEnumerator<V>
			{
				_map = _map
			};
		}
	}

	public struct ImMapEnumerator<V> : IEnumerator<ImMapEntry<V>>, IEnumerator, IDisposable
	{
		internal ImMap<V> _map;

		private short _state;

		private ushort _index;

		private ImMapStack<V> _ps;

		private ImMap<V> _nextBranch;

		private ImMap<V>.Branch2Plus1 _b21LeftWasEnumerated;

		private ImMapEntry<V> _a;

		private ImMapEntry<V> _b;

		private ImMapEntry<V> _c;

		private ImMapEntry<V> _d;

		private ImMapEntry<V> _e;

		private ImMapEntry<V> _f;

		private ImMapEntry<V> _g;

		private ImMapEntry<V> _h;

		private ImMapEntry<V> _current;

		public ImMapEntry<V> Current => _current;

		object IEnumerator.Current => _current;

		public bool MoveNext()
		{
			ImMap<V>.Leaf5Plus1Plus1 leaf5Plus1Plus2;
			ImMap<V> map;
			ImMap<V>.Leaf5 l5;
			ImMapEntry<V> imMapEntry9;
			int hash5;
			ImMapEntry<V> imMapEntry10;
			switch (_state)
			{
			case 0:
				_state = -1;
				if (_map == ImMap<V>.Empty)
				{
					return false;
				}
				if (_map is ImMapEntry<V> current2)
				{
					_current = current2;
					_state = 1;
					return true;
				}
				goto IL_0526;
			case 1:
				_state = -1;
				_current = null;
				return false;
			case 2:
				_state = -1;
				leaf5Plus1Plus2 = (ImMap<V>.Leaf5Plus1Plus1)_b21LeftWasEnumerated.B.Right;
				_g = _b21LeftWasEnumerated.Plus;
				_b21LeftWasEnumerated = null;
				_map = ImMap<V>.Empty;
				goto IL_0688;
			case 3:
				_current = _a;
				_state = 4;
				return true;
			case 4:
				_current = _b;
				_state = 5;
				return true;
			case 5:
				_current = _c;
				_state = 6;
				return true;
			case 6:
				_current = _d;
				_state = 7;
				return true;
			case 7:
				_current = _e;
				_state = 8;
				return true;
			case 8:
				_current = _f;
				_state = 9;
				return true;
			case 9:
				_current = _g;
				_state = 10;
				return true;
			case 10:
				_state = -1;
				if (_h != null)
				{
					_current = _h;
					_state = 11;
					return true;
				}
				goto IL_0a27;
			case 11:
				_state = -1;
				goto IL_0a27;
			case 12:
				_current = _a;
				_state = 13;
				return true;
			case 13:
				_state = -1;
				goto IL_04de;
			case 14:
				_current = _h;
				_state = 15;
				return true;
			case 15:
				_current = _g;
				_state = 16;
				return true;
			case 16:
				_state = -1;
				_h = null;
				_g = null;
				goto IL_04de;
			case 17:
				_current = _g;
				_state = 18;
				return true;
			case 18:
				_current = _h;
				_state = 19;
				return true;
			case 19:
				_current = _e;
				_state = 20;
				return true;
			case 20:
				_state = -1;
				_g = null;
				_h = null;
				_e = null;
				goto IL_04de;
			case 21:
				_current = _a;
				_state = 22;
				return true;
			case 22:
				_current = _b;
				_state = 23;
				return true;
			case 23:
				_current = _c;
				_state = 24;
				return true;
			case 24:
				_current = _d;
				_state = 25;
				return true;
			case 25:
				_state = -1;
				goto IL_04c2;
			case 26:
				_current = _e;
				_state = 27;
				return true;
			case 27:
				_current = _h;
				_state = 28;
				return true;
			case 28:
				_current = _g;
				_state = 29;
				return true;
			case 29:
				_current = _f;
				_state = 30;
				return true;
			case 30:
				_current = _d;
				_state = 31;
				return true;
			case 31:
				_state = -1;
				_e = null;
				_h = null;
				_g = null;
				_f = null;
				_d = null;
				goto IL_04c2;
			case 32:
				_current = _d;
				_state = 33;
				return true;
			case 33:
				_current = _f;
				_state = 34;
				return true;
			case 34:
				_current = _g;
				_state = 35;
				return true;
			case 35:
				_current = _h;
				_state = 36;
				return true;
			case 36:
				_current = _c;
				_state = 37;
				return true;
			case 37:
				_current = _e;
				_state = 38;
				return true;
			case 38:
				_state = -1;
				_d = null;
				_f = null;
				_g = null;
				_h = null;
				_e = null;
				_c = null;
				goto IL_04c2;
			case 39:
				_state = -1;
				goto IL_04c2;
			case 40:
				_state = -1;
				_map = _nextBranch;
				_a = null;
				_nextBranch = null;
				goto IL_0526;
			default:
				{
					return false;
				}
				IL_0a5f:
				map = _map;
				if (map is ImMap<V>.Leaf2 leaf)
				{
					_current = leaf.Entry0;
					_a = leaf.Entry1;
					_state = 12;
					return true;
				}
				if (map is ImMap<V>.Leaf2Plus1 { L: var l } leaf2Plus)
				{
					ImMapEntry<V> imMapEntry = l.Entry0;
					ImMapEntry<V> imMapEntry2 = null;
					_h = l.Entry1;
					_g = leaf2Plus.Plus;
					int hash = _g.Hash;
					if (hash < _h.Hash)
					{
						imMapEntry2 = _h;
						_h = _g;
						_g = imMapEntry2;
						if (hash < imMapEntry.Hash)
						{
							imMapEntry2 = imMapEntry;
							imMapEntry = _h;
							_h = imMapEntry2;
						}
					}
					_current = imMapEntry;
					_state = 14;
					return true;
				}
				if (map is ImMap<V>.Leaf2Plus1Plus1 leaf2Plus1Plus)
				{
					ImMap<V>.Leaf2 l2 = leaf2Plus1Plus.L.L;
					ImMapEntry<V> imMapEntry3 = l2.Entry0;
					ImMapEntry<V> imMapEntry4 = null;
					_g = l2.Entry1;
					_h = leaf2Plus1Plus.L.Plus;
					_e = leaf2Plus1Plus.Plus;
					int hash2 = _h.Hash;
					if (hash2 < _g.Hash)
					{
						imMapEntry4 = _g;
						_g = _h;
						_h = imMapEntry4;
						if (hash2 < imMapEntry3.Hash)
						{
							imMapEntry4 = imMapEntry3;
							imMapEntry3 = _g;
							_g = imMapEntry4;
						}
					}
					hash2 = _e.Hash;
					if (hash2 < _h.Hash)
					{
						imMapEntry4 = _h;
						_h = _e;
						_e = imMapEntry4;
						if (hash2 < _g.Hash)
						{
							imMapEntry4 = _g;
							_g = _h;
							_h = imMapEntry4;
							if (hash2 < imMapEntry3.Hash)
							{
								imMapEntry4 = imMapEntry3;
								imMapEntry3 = _g;
								_g = imMapEntry4;
							}
						}
					}
					_current = imMapEntry3;
					_state = 17;
					return true;
				}
				if (map is ImMap<V>.Leaf5 leaf2)
				{
					_current = leaf2.Entry0;
					_a = leaf2.Entry1;
					_b = leaf2.Entry2;
					_c = leaf2.Entry3;
					_d = leaf2.Entry4;
					_state = 21;
					return true;
				}
				if (map is ImMap<V>.Leaf5Plus1 { L: var l3 } leaf5Plus)
				{
					ImMapEntry<V> imMapEntry5 = l3.Entry0;
					ImMapEntry<V> imMapEntry6 = null;
					_e = l3.Entry1;
					_h = l3.Entry2;
					_g = l3.Entry3;
					_f = l3.Entry4;
					_d = leaf5Plus.Plus;
					int hash3 = _d.Hash;
					if (hash3 < _f.Hash)
					{
						imMapEntry6 = _f;
						_f = _d;
						_d = imMapEntry6;
						if (hash3 < _g.Hash)
						{
							imMapEntry6 = _g;
							_g = _f;
							_f = imMapEntry6;
							if (hash3 < _h.Hash)
							{
								imMapEntry6 = _h;
								_h = _g;
								_g = imMapEntry6;
								if (hash3 < _e.Hash)
								{
									imMapEntry6 = _e;
									_e = _h;
									_h = imMapEntry6;
									if (hash3 < imMapEntry5.Hash)
									{
										imMapEntry6 = imMapEntry5;
										imMapEntry5 = _e;
										_e = imMapEntry6;
									}
								}
							}
						}
					}
					_current = imMapEntry5;
					_state = 26;
					return true;
				}
				if (map is ImMap<V>.Leaf5Plus1Plus1 leaf5Plus1Plus)
				{
					ImMap<V>.Leaf5 l4 = leaf5Plus1Plus.L.L;
					ImMapEntry<V> imMapEntry7 = l4.Entry0;
					ImMapEntry<V> imMapEntry8 = null;
					_d = l4.Entry1;
					_f = l4.Entry2;
					_g = l4.Entry3;
					_h = l4.Entry4;
					_c = leaf5Plus1Plus.L.Plus;
					_e = leaf5Plus1Plus.Plus;
					int hash4 = _c.Hash;
					if (hash4 < _h.Hash)
					{
						imMapEntry8 = _h;
						_h = _c;
						_c = imMapEntry8;
						if (hash4 < _g.Hash)
						{
							imMapEntry8 = _g;
							_g = _h;
							_h = imMapEntry8;
							if (hash4 < _f.Hash)
							{
								imMapEntry8 = _f;
								_f = _g;
								_g = imMapEntry8;
								if (hash4 < _d.Hash)
								{
									imMapEntry8 = _d;
									_d = _f;
									_f = imMapEntry8;
									if (hash4 < imMapEntry7.Hash)
									{
										imMapEntry8 = imMapEntry7;
										imMapEntry7 = _d;
										_d = imMapEntry8;
									}
								}
							}
						}
					}
					hash4 = _e.Hash;
					if (hash4 < _c.Hash)
					{
						imMapEntry8 = _c;
						_c = _e;
						_e = imMapEntry8;
						if (hash4 < _h.Hash)
						{
							imMapEntry8 = _h;
							_h = _c;
							_c = imMapEntry8;
							if (hash4 < _g.Hash)
							{
								imMapEntry8 = _g;
								_g = _h;
								_h = imMapEntry8;
								if (hash4 < _f.Hash)
								{
									imMapEntry8 = _f;
									_f = _g;
									_g = imMapEntry8;
									if (hash4 < _d.Hash)
									{
										imMapEntry8 = _d;
										_d = _f;
										_f = imMapEntry8;
										if (hash4 < imMapEntry7.Hash)
										{
											imMapEntry8 = imMapEntry7;
											imMapEntry7 = _d;
											_d = imMapEntry8;
										}
									}
								}
							}
						}
					}
					_current = imMapEntry7;
					_state = 32;
					return true;
				}
				if (map is ImMapEntry<V> current)
				{
					_current = current;
					_state = 39;
					return true;
				}
				goto IL_04c2;
				IL_0a27:
				_a = null;
				_b = null;
				_c = null;
				_d = null;
				_e = null;
				_f = null;
				goto IL_0a51;
				IL_0a51:
				_g = null;
				_h = null;
				goto IL_0a5f;
				IL_04de:
				if (_b21LeftWasEnumerated == null)
				{
					if (_index == 0)
					{
						return false;
					}
					_ps.Get(--_index, ref _current, ref _nextBranch);
					_state = 40;
					return true;
				}
				goto IL_0526;
				IL_0688:
				l5 = leaf5Plus1Plus2.L.L;
				imMapEntry9 = l5.Entry0;
				imMapEntry10 = null;
				_a = l5.Entry1;
				_b = l5.Entry2;
				_c = l5.Entry3;
				_d = l5.Entry4;
				_f = leaf5Plus1Plus2.Plus;
				_e = leaf5Plus1Plus2.L.Plus;
				hash5 = _e.Hash;
				if (hash5 < _d.Hash)
				{
					imMapEntry10 = _d;
					_d = _e;
					_e = imMapEntry10;
					if (hash5 < _c.Hash)
					{
						imMapEntry10 = _c;
						_c = _d;
						_d = imMapEntry10;
						if (hash5 < _b.Hash)
						{
							imMapEntry10 = _b;
							_b = _c;
							_c = imMapEntry10;
							if (hash5 < _a.Hash)
							{
								imMapEntry10 = _a;
								_a = _b;
								_b = imMapEntry10;
								if (hash5 < imMapEntry9.Hash)
								{
									imMapEntry10 = imMapEntry9;
									imMapEntry9 = _a;
									_a = imMapEntry10;
								}
							}
						}
					}
				}
				hash5 = _f.Hash;
				if (hash5 < _e.Hash)
				{
					imMapEntry10 = _e;
					_e = _f;
					_f = imMapEntry10;
					if (hash5 < _d.Hash)
					{
						imMapEntry10 = _d;
						_d = _e;
						_e = imMapEntry10;
						if (hash5 < _c.Hash)
						{
							imMapEntry10 = _c;
							_c = _d;
							_d = imMapEntry10;
							if (hash5 < _b.Hash)
							{
								imMapEntry10 = _b;
								_b = _c;
								_c = imMapEntry10;
								if (hash5 < _a.Hash)
								{
									imMapEntry10 = _a;
									_a = _b;
									_b = imMapEntry10;
									if (hash5 < imMapEntry9.Hash)
									{
										imMapEntry10 = imMapEntry9;
										imMapEntry9 = _a;
										_a = imMapEntry10;
									}
								}
							}
						}
					}
				}
				hash5 = _g.Hash;
				if (hash5 < _f.Hash)
				{
					imMapEntry10 = _f;
					_f = _g;
					_g = imMapEntry10;
					if (hash5 < _e.Hash)
					{
						imMapEntry10 = _e;
						_e = _f;
						_f = imMapEntry10;
						if (hash5 < _d.Hash)
						{
							imMapEntry10 = _d;
							_d = _e;
							_e = imMapEntry10;
							if (hash5 < _c.Hash)
							{
								imMapEntry10 = _c;
								_c = _d;
								_d = imMapEntry10;
								if (hash5 < _b.Hash)
								{
									imMapEntry10 = _b;
									_b = _c;
									_c = imMapEntry10;
									if (hash5 < _a.Hash)
									{
										imMapEntry10 = _a;
										_a = _b;
										_b = imMapEntry10;
										if (hash5 < imMapEntry9.Hash)
										{
											imMapEntry10 = imMapEntry9;
											imMapEntry9 = _a;
											_a = imMapEntry10;
										}
									}
								}
							}
						}
					}
				}
				_current = imMapEntry9;
				_state = 3;
				return true;
				IL_0526:
				while (true)
				{
					if (_map is ImMap<V>.Branch2 branch)
					{
						_ps.Put(_index++, branch.MidEntry, branch.Right);
						_map = branch.Left;
						continue;
					}
					if (!(_map is ImMap<V>.Branch3 branch2))
					{
						break;
					}
					_ps.Put(_index, branch2.Entry1, branch2.Right, branch2.Entry0, branch2.Middle);
					_index += 2;
					_map = branch2.Left;
				}
				if (_b21LeftWasEnumerated != null || _map is ImMap<V>.Branch2Plus1)
				{
					_g = null;
					_h = null;
					if (_b21LeftWasEnumerated != null)
					{
						_current = _b21LeftWasEnumerated.B.MidEntry;
						_state = 2;
						return true;
					}
					ImMap<V>.Branch2Plus1 branch2Plus = (ImMap<V>.Branch2Plus1)_map;
					ImMap<V>.Branch2 b = branch2Plus.B;
					if (b.Right is ImMap<V>.Leaf5Plus1Plus1)
					{
						_b21LeftWasEnumerated = branch2Plus;
						_map = b.Left;
						goto IL_0a51;
					}
					leaf5Plus1Plus2 = (ImMap<V>.Leaf5Plus1Plus1)b.Left;
					_h = b.MidEntry;
					_g = branch2Plus.Plus;
					_map = b.Right;
					goto IL_0688;
				}
				goto IL_0a5f;
				IL_04c2:
				_a = null;
				_b = null;
				_c = null;
				_d = null;
				goto IL_04de;
			}
		}

		bool IEnumerator.MoveNext()
		{
			return MoveNext();
		}

		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		void IDisposable.Dispose()
		{
		}
	}

	private static readonly object _enumerationB3Tombstone = new object();

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ImMapEntry<V> Entry<V>(int hash, V value)
	{
		return new ImMapEntry<V>(hash, value);
	}

	public static ImMapEnumerable<V> Enumerate<V>(this ImMap<V> map)
	{
		return new ImMapEnumerable<V>(map);
	}

	public static S ForEach<V, S>(this ImMap<V> map, S state, Action<ImMapEntry<V>, int, S> handler, MapParentStack parents = null)
	{
		if (map == ImMap<V>.Empty)
		{
			return state;
		}
		if (map is ImMapEntry<V> arg)
		{
			handler(arg, 0, state);
			return state;
		}
		ImMap<V>.Branch2Plus1 branch2Plus = null;
		int num = 0;
		int num2 = 0;
		while (true)
		{
			if (map is ImMap<V>.Branch2 branch)
			{
				if (parents == null)
				{
					parents = new MapParentStack();
				}
				parents.Put(map, num++);
				map = branch.Left;
				continue;
			}
			if (map is ImMap<V>.Branch3 branch2)
			{
				if (parents == null)
				{
					parents = new MapParentStack();
				}
				parents.Put(map, num++);
				map = branch2.Left;
				continue;
			}
			if (branch2Plus != null || map is ImMap<V>.Branch2Plus1)
			{
				ImMap<V>.Leaf5Plus1Plus1 leaf5Plus1Plus = null;
				ImMapEntry<V> imMapEntry = null;
				ImMapEntry<V> imMapEntry2 = null;
				if (branch2Plus != null)
				{
					handler(branch2Plus.B.MidEntry, num2++, state);
					leaf5Plus1Plus = (ImMap<V>.Leaf5Plus1Plus1)branch2Plus.B.Right;
					imMapEntry = branch2Plus.Plus;
					branch2Plus = null;
					map = ImMap<V>.Empty;
				}
				else
				{
					ImMap<V>.Branch2Plus1 branch2Plus2 = (ImMap<V>.Branch2Plus1)map;
					if (branch2Plus2.B.Right is ImMap<V>.Leaf5Plus1Plus1)
					{
						branch2Plus = branch2Plus2;
						map = branch2Plus2.B.Left;
					}
					else
					{
						leaf5Plus1Plus = (ImMap<V>.Leaf5Plus1Plus1)branch2Plus2.B.Left;
						imMapEntry2 = branch2Plus2.B.MidEntry;
						imMapEntry = branch2Plus2.Plus;
						map = branch2Plus2.B.Right;
					}
				}
				if (leaf5Plus1Plus != null)
				{
					ImMap<V>.Leaf5 l = leaf5Plus1Plus.L.L;
					ImMapEntry<V> imMapEntry3 = l.Entry0;
					ImMapEntry<V> imMapEntry4 = l.Entry1;
					ImMapEntry<V> imMapEntry5 = l.Entry2;
					ImMapEntry<V> imMapEntry6 = l.Entry3;
					ImMapEntry<V> imMapEntry7 = l.Entry4;
					ImMapEntry<V> imMapEntry8 = leaf5Plus1Plus.Plus;
					ImMapEntry<V> imMapEntry9 = leaf5Plus1Plus.L.Plus;
					ImMapEntry<V> imMapEntry10 = null;
					int hash = imMapEntry9.Hash;
					if (hash < imMapEntry7.Hash)
					{
						imMapEntry10 = imMapEntry7;
						imMapEntry7 = imMapEntry9;
						imMapEntry9 = imMapEntry10;
						if (hash < imMapEntry6.Hash)
						{
							imMapEntry10 = imMapEntry6;
							imMapEntry6 = imMapEntry7;
							imMapEntry7 = imMapEntry10;
							if (hash < imMapEntry5.Hash)
							{
								imMapEntry10 = imMapEntry5;
								imMapEntry5 = imMapEntry6;
								imMapEntry6 = imMapEntry10;
								if (hash < imMapEntry4.Hash)
								{
									imMapEntry10 = imMapEntry4;
									imMapEntry4 = imMapEntry5;
									imMapEntry5 = imMapEntry10;
									if (hash < imMapEntry3.Hash)
									{
										imMapEntry10 = imMapEntry3;
										imMapEntry3 = imMapEntry4;
										imMapEntry4 = imMapEntry10;
									}
								}
							}
						}
					}
					hash = imMapEntry8.Hash;
					if (hash < imMapEntry9.Hash)
					{
						imMapEntry10 = imMapEntry9;
						imMapEntry9 = imMapEntry8;
						imMapEntry8 = imMapEntry10;
						if (hash < imMapEntry7.Hash)
						{
							imMapEntry10 = imMapEntry7;
							imMapEntry7 = imMapEntry9;
							imMapEntry9 = imMapEntry10;
							if (hash < imMapEntry6.Hash)
							{
								imMapEntry10 = imMapEntry6;
								imMapEntry6 = imMapEntry7;
								imMapEntry7 = imMapEntry10;
								if (hash < imMapEntry5.Hash)
								{
									imMapEntry10 = imMapEntry5;
									imMapEntry5 = imMapEntry6;
									imMapEntry6 = imMapEntry10;
									if (hash < imMapEntry4.Hash)
									{
										imMapEntry10 = imMapEntry4;
										imMapEntry4 = imMapEntry5;
										imMapEntry5 = imMapEntry10;
										if (hash < imMapEntry3.Hash)
										{
											imMapEntry10 = imMapEntry3;
											imMapEntry3 = imMapEntry4;
											imMapEntry4 = imMapEntry10;
										}
									}
								}
							}
						}
					}
					hash = imMapEntry.Hash;
					if (hash < imMapEntry8.Hash)
					{
						imMapEntry10 = imMapEntry8;
						imMapEntry8 = imMapEntry;
						imMapEntry = imMapEntry10;
						if (hash < imMapEntry9.Hash)
						{
							imMapEntry10 = imMapEntry9;
							imMapEntry9 = imMapEntry8;
							imMapEntry8 = imMapEntry10;
							if (hash < imMapEntry7.Hash)
							{
								imMapEntry10 = imMapEntry7;
								imMapEntry7 = imMapEntry9;
								imMapEntry9 = imMapEntry10;
								if (hash < imMapEntry6.Hash)
								{
									imMapEntry10 = imMapEntry6;
									imMapEntry6 = imMapEntry7;
									imMapEntry7 = imMapEntry10;
									if (hash < imMapEntry5.Hash)
									{
										imMapEntry10 = imMapEntry5;
										imMapEntry5 = imMapEntry6;
										imMapEntry6 = imMapEntry10;
										if (hash < imMapEntry4.Hash)
										{
											imMapEntry10 = imMapEntry4;
											imMapEntry4 = imMapEntry5;
											imMapEntry5 = imMapEntry10;
											if (hash < imMapEntry3.Hash)
											{
												imMapEntry10 = imMapEntry3;
												imMapEntry3 = imMapEntry4;
												imMapEntry4 = imMapEntry10;
											}
										}
									}
								}
							}
						}
					}
					handler(imMapEntry3, num2++, state);
					handler(imMapEntry4, num2++, state);
					handler(imMapEntry5, num2++, state);
					handler(imMapEntry6, num2++, state);
					handler(imMapEntry7, num2++, state);
					handler(imMapEntry9, num2++, state);
					handler(imMapEntry8, num2++, state);
					handler(imMapEntry, num2++, state);
					if (imMapEntry2 != null)
					{
						handler(imMapEntry2, num2++, state);
					}
				}
			}
			if (map is ImMap<V>.Leaf2 leaf)
			{
				handler(leaf.Entry0, num2++, state);
				handler(leaf.Entry1, num2++, state);
			}
			else if (map is ImMap<V>.Leaf2Plus1 { L: var l2 } leaf2Plus)
			{
				ImMapEntry<V> imMapEntry11 = l2.Entry0;
				ImMapEntry<V> imMapEntry12 = l2.Entry1;
				ImMapEntry<V> imMapEntry13 = leaf2Plus.Plus;
				ImMapEntry<V> imMapEntry14 = null;
				int hash2 = imMapEntry13.Hash;
				if (hash2 < imMapEntry12.Hash)
				{
					imMapEntry14 = imMapEntry12;
					imMapEntry12 = imMapEntry13;
					imMapEntry13 = imMapEntry14;
					if (hash2 < imMapEntry11.Hash)
					{
						imMapEntry14 = imMapEntry11;
						imMapEntry11 = imMapEntry12;
						imMapEntry12 = imMapEntry14;
					}
				}
				handler(imMapEntry11, num2++, state);
				handler(imMapEntry12, num2++, state);
				handler(imMapEntry13, num2++, state);
			}
			else if (map is ImMap<V>.Leaf2Plus1Plus1 leaf2Plus1Plus)
			{
				ImMap<V>.Leaf2 l3 = leaf2Plus1Plus.L.L;
				ImMapEntry<V> imMapEntry15 = l3.Entry0;
				ImMapEntry<V> imMapEntry16 = l3.Entry1;
				ImMapEntry<V> imMapEntry17 = leaf2Plus1Plus.L.Plus;
				ImMapEntry<V> imMapEntry18 = leaf2Plus1Plus.Plus;
				ImMapEntry<V> imMapEntry19 = null;
				int hash3 = imMapEntry17.Hash;
				if (hash3 < imMapEntry16.Hash)
				{
					imMapEntry19 = imMapEntry16;
					imMapEntry16 = imMapEntry17;
					imMapEntry17 = imMapEntry19;
					if (hash3 < imMapEntry15.Hash)
					{
						imMapEntry19 = imMapEntry15;
						imMapEntry15 = imMapEntry16;
						imMapEntry16 = imMapEntry19;
					}
				}
				hash3 = imMapEntry18.Hash;
				if (hash3 < imMapEntry17.Hash)
				{
					imMapEntry19 = imMapEntry17;
					imMapEntry17 = imMapEntry18;
					imMapEntry18 = imMapEntry19;
					if (hash3 < imMapEntry16.Hash)
					{
						imMapEntry19 = imMapEntry16;
						imMapEntry16 = imMapEntry17;
						imMapEntry17 = imMapEntry19;
						if (hash3 < imMapEntry15.Hash)
						{
							imMapEntry19 = imMapEntry15;
							imMapEntry15 = imMapEntry16;
							imMapEntry16 = imMapEntry19;
						}
					}
				}
				handler(imMapEntry15, num2++, state);
				handler(imMapEntry16, num2++, state);
				handler(imMapEntry17, num2++, state);
				handler(imMapEntry18, num2++, state);
			}
			else if (map is ImMap<V>.Leaf5 leaf2)
			{
				handler(leaf2.Entry0, num2++, state);
				handler(leaf2.Entry1, num2++, state);
				handler(leaf2.Entry2, num2++, state);
				handler(leaf2.Entry3, num2++, state);
				handler(leaf2.Entry4, num2++, state);
			}
			else if (map is ImMap<V>.Leaf5Plus1 { L: var l4 } leaf5Plus)
			{
				ImMapEntry<V> imMapEntry20 = l4.Entry0;
				ImMapEntry<V> imMapEntry21 = l4.Entry1;
				ImMapEntry<V> imMapEntry22 = l4.Entry2;
				ImMapEntry<V> imMapEntry23 = l4.Entry3;
				ImMapEntry<V> imMapEntry24 = l4.Entry4;
				ImMapEntry<V> imMapEntry25 = leaf5Plus.Plus;
				ImMapEntry<V> imMapEntry26 = null;
				int hash4 = imMapEntry25.Hash;
				if (hash4 < imMapEntry24.Hash)
				{
					imMapEntry26 = imMapEntry24;
					imMapEntry24 = imMapEntry25;
					imMapEntry25 = imMapEntry26;
					if (hash4 < imMapEntry23.Hash)
					{
						imMapEntry26 = imMapEntry23;
						imMapEntry23 = imMapEntry24;
						imMapEntry24 = imMapEntry26;
						if (hash4 < imMapEntry22.Hash)
						{
							imMapEntry26 = imMapEntry22;
							imMapEntry22 = imMapEntry23;
							imMapEntry23 = imMapEntry26;
							if (hash4 < imMapEntry21.Hash)
							{
								imMapEntry26 = imMapEntry21;
								imMapEntry21 = imMapEntry22;
								imMapEntry22 = imMapEntry26;
								if (hash4 < imMapEntry20.Hash)
								{
									imMapEntry26 = imMapEntry20;
									imMapEntry20 = imMapEntry21;
									imMapEntry21 = imMapEntry26;
								}
							}
						}
					}
				}
				handler(imMapEntry20, num2++, state);
				handler(imMapEntry21, num2++, state);
				handler(imMapEntry22, num2++, state);
				handler(imMapEntry23, num2++, state);
				handler(imMapEntry24, num2++, state);
				handler(imMapEntry25, num2++, state);
			}
			else if (map is ImMap<V>.Leaf5Plus1Plus1 leaf5Plus1Plus2)
			{
				ImMap<V>.Leaf5 l5 = leaf5Plus1Plus2.L.L;
				ImMapEntry<V> imMapEntry27 = l5.Entry0;
				ImMapEntry<V> imMapEntry28 = l5.Entry1;
				ImMapEntry<V> imMapEntry29 = l5.Entry2;
				ImMapEntry<V> imMapEntry30 = l5.Entry3;
				ImMapEntry<V> imMapEntry31 = l5.Entry4;
				ImMapEntry<V> imMapEntry32 = leaf5Plus1Plus2.Plus;
				ImMapEntry<V> imMapEntry33 = leaf5Plus1Plus2.L.Plus;
				ImMapEntry<V> imMapEntry34 = null;
				int hash5 = imMapEntry33.Hash;
				if (hash5 < imMapEntry31.Hash)
				{
					imMapEntry34 = imMapEntry31;
					imMapEntry31 = imMapEntry33;
					imMapEntry33 = imMapEntry34;
					if (hash5 < imMapEntry30.Hash)
					{
						imMapEntry34 = imMapEntry30;
						imMapEntry30 = imMapEntry31;
						imMapEntry31 = imMapEntry34;
						if (hash5 < imMapEntry29.Hash)
						{
							imMapEntry34 = imMapEntry29;
							imMapEntry29 = imMapEntry30;
							imMapEntry30 = imMapEntry34;
							if (hash5 < imMapEntry28.Hash)
							{
								imMapEntry34 = imMapEntry28;
								imMapEntry28 = imMapEntry29;
								imMapEntry29 = imMapEntry34;
								if (hash5 < imMapEntry27.Hash)
								{
									imMapEntry34 = imMapEntry27;
									imMapEntry27 = imMapEntry28;
									imMapEntry28 = imMapEntry34;
								}
							}
						}
					}
				}
				hash5 = imMapEntry32.Hash;
				if (hash5 < imMapEntry33.Hash)
				{
					imMapEntry34 = imMapEntry33;
					imMapEntry33 = imMapEntry32;
					imMapEntry32 = imMapEntry34;
					if (hash5 < imMapEntry31.Hash)
					{
						imMapEntry34 = imMapEntry31;
						imMapEntry31 = imMapEntry33;
						imMapEntry33 = imMapEntry34;
						if (hash5 < imMapEntry30.Hash)
						{
							imMapEntry34 = imMapEntry30;
							imMapEntry30 = imMapEntry31;
							imMapEntry31 = imMapEntry34;
							if (hash5 < imMapEntry29.Hash)
							{
								imMapEntry34 = imMapEntry29;
								imMapEntry29 = imMapEntry30;
								imMapEntry30 = imMapEntry34;
								if (hash5 < imMapEntry28.Hash)
								{
									imMapEntry34 = imMapEntry28;
									imMapEntry28 = imMapEntry29;
									imMapEntry29 = imMapEntry34;
									if (hash5 < imMapEntry27.Hash)
									{
										imMapEntry34 = imMapEntry27;
										imMapEntry27 = imMapEntry28;
										imMapEntry28 = imMapEntry34;
									}
								}
							}
						}
					}
				}
				handler(imMapEntry27, num2++, state);
				handler(imMapEntry28, num2++, state);
				handler(imMapEntry29, num2++, state);
				handler(imMapEntry30, num2++, state);
				handler(imMapEntry31, num2++, state);
				handler(imMapEntry33, num2++, state);
				handler(imMapEntry32, num2++, state);
			}
			else if (map is ImMapEntry<V> arg2)
			{
				handler(arg2, num2++, state);
			}
			if (branch2Plus == null)
			{
				if (num == 0)
				{
					break;
				}
				object obj = parents.Get(--num);
				if (obj is ImMap<V>.Branch2 branch3)
				{
					handler(branch3.MidEntry, num2++, state);
					map = branch3.Right;
				}
				else if (obj != _enumerationB3Tombstone)
				{
					ImMap<V>.Branch3 branch4 = (ImMap<V>.Branch3)obj;
					handler(branch4.Entry0, num2++, state);
					map = branch4.Middle;
					parents.Put(_enumerationB3Tombstone, ++num);
					num++;
				}
				else
				{
					ImMap<V>.Branch3 branch5 = (ImMap<V>.Branch3)parents.Get(--num);
					handler(branch5.Entry1, num2++, state);
					map = branch5.Right;
				}
			}
		}
		return state;
	}

	public static void ForEach<V>(this ImMap<V> map, Action<ImMapEntry<V>, int> handler, MapParentStack parents = null)
	{
		map.ForEach(handler, delegate(ImMapEntry<V> e, int i, Action<ImMapEntry<V>, int> r)
		{
			r(e, i);
		}, parents);
	}

	public static S Fold<V, S>(this ImMap<V> map, S state, Func<ImMapEntry<V>, int, S, S> handler, MapParentStack parents = null)
	{
		return map.ForEach(St.Rent(state, handler), delegate(ImMapEntry<V> e, int i, St<S, Func<ImMapEntry<V>, int, S, S>> s)
		{
			s.a = s.b(e, i, s.a);
		}, parents).ResetButGetA();
	}

	public static S[] ToArray<V, S>(this ImMap<V> map, Func<ImMapEntry<V>, S> selector)
	{
		if (map != ImMap<V>.Empty)
		{
			return map.ForEach(St.Rent(new S[map.Count()], selector), delegate(ImMapEntry<V> e, int i, St<S[], Func<ImMapEntry<V>, S>> s)
			{
				s.a[i] = s.b(e);
			}).ResetButGetA();
		}
		return ArrayTools.Empty<S>();
	}

	public static ImMapEntry<V>[] ToArray<V>(this ImMap<V> map)
	{
		if (map != ImMap<V>.Empty)
		{
			return map.ForEach(new ImMapEntry<V>[map.Count()], delegate(ImMapEntry<V> e, int i, ImMapEntry<V>[] a)
			{
				a[i] = e;
			});
		}
		return ArrayTools.Empty<ImMapEntry<V>>();
	}

	public static Dictionary<int, V> ToDictionary<V>(this ImMap<V> map)
	{
		if (map != ImMap<V>.Empty)
		{
			return map.ForEach(new Dictionary<int, V>(), delegate(ImMapEntry<V> e, int _, Dictionary<int, V> d)
			{
				d.Add(e.Hash, e.Value);
			});
		}
		return new Dictionary<int, V>(0);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ImMapEntry<V> GetSurePresentEntry<V>(this ImMap<V> map, int hash)
	{
		return map.GetEntryOrNull(hash);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ImMapEntry<V> GetEntryOrDefault<V>(this ImMap<V> map, int hash)
	{
		return map.GetEntryOrNull(hash);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static V GetValueOrDefault<V>(this ImMap<V> map, int hash)
	{
		ImMapEntry<V> entryOrNull = map.GetEntryOrNull(hash);
		if (entryOrNull == null)
		{
			return default(V);
		}
		return entryOrNull.Value;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryFind<V>(this ImMap<V> map, int hash, out V value)
	{
		if (map is ImMapEntry<V> imMapEntry)
		{
			if (imMapEntry.Hash == hash)
			{
				value = imMapEntry.Value;
				return true;
			}
		}
		else
		{
			ImMapEntry<V> entryOrNull = map.GetEntryOrNull(hash);
			if (entryOrNull != null)
			{
				value = entryOrNull.Value;
				return true;
			}
		}
		value = default(V);
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ImMap<V> AddOrGetEntry<V>(this ImMap<V> map, ImMapEntry<V> newEntry)
	{
		if (map != ImMap<V>.Empty)
		{
			return map.AddOrGetEntry(newEntry.Hash, newEntry);
		}
		return newEntry;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ImMap<V> AddOrUpdateEntry<V>(this ImMap<V> map, ImMapEntry<V> newEntry)
	{
		int hash = newEntry.Hash;
		ImMap<V> imMap = map.AddOrGetEntry(hash, newEntry);
		if (!(imMap is ImMapEntry<V> imMapEntry))
		{
			return imMap;
		}
		if (imMapEntry != newEntry)
		{
			return map.ReplaceEntry(hash, imMapEntry, newEntry);
		}
		return newEntry;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ImMap<V> AddOrUpdate<V>(this ImMap<V> map, int hash, V value)
	{
		ImMapEntry<V> imMapEntry = new ImMapEntry<V>(hash, value);
		ImMap<V> imMap = map.AddOrGetEntry(hash, imMapEntry);
		if (!(imMap is ImMapEntry<V> imMapEntry2))
		{
			return imMap;
		}
		if (imMapEntry2 != imMapEntry)
		{
			return map.ReplaceEntry(hash, imMapEntry2, imMapEntry);
		}
		return imMapEntry;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ImMap<V> AddOrUpdate<V>(this ImMap<V> map, int hash, V value, Update<int, V> update)
	{
		ImMapEntry<V> imMapEntry = new ImMapEntry<V>(hash, value);
		ImMap<V> imMap = map.AddOrGetEntry(hash, imMapEntry);
		if (!(imMap is ImMapEntry<V> imMapEntry2))
		{
			return imMap;
		}
		if (imMapEntry2 != imMapEntry)
		{
			return map.ReplaceEntry(hash, imMapEntry2, new ImMapEntry<V>(hash, update(hash, imMapEntry2.Value, value)));
		}
		return imMapEntry;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ImMap<V> Update<V>(this ImMap<V> map, int hash, V value)
	{
		ImMapEntry<V> entryOrNull = map.GetEntryOrNull(hash);
		if (entryOrNull != null)
		{
			return map.ReplaceEntry(hash, entryOrNull, new ImMapEntry<V>(hash, value));
		}
		return map;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ImMap<V> UpdateToDefault<V>(this ImMap<V> map, int hash)
	{
		ImMapEntry<V> entryOrNull = map.GetEntryOrNull(hash);
		if (entryOrNull != null)
		{
			return map.ReplaceEntry(hash, entryOrNull, new ImMapEntry<V>(hash));
		}
		return map;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ImMap<V> AddOrKeepEntry<V>(this ImMap<V> map, ImMapEntry<V> newEntry)
	{
		ImMap<V> imMap = map.AddOrGetEntry(newEntry.Hash, newEntry);
		if (!(imMap is ImMapEntry<V>) || imMap == newEntry)
		{
			return imMap;
		}
		return map;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ImMap<V> AddOrKeep<V>(this ImMap<V> map, int hash, V value)
	{
		ImMapEntry<V> imMapEntry = new ImMapEntry<V>(hash, value);
		ImMap<V> imMap = map.AddOrGetEntry(hash, imMapEntry);
		if (!(imMap is ImMapEntry<V>) || imMap == imMapEntry)
		{
			return imMap;
		}
		return map;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ImMap<V> Remove<V>(this ImMap<V> map, int hash)
	{
		ImMapEntry<V> entryOrNull = map.GetEntryOrNull(hash);
		if (entryOrNull != null)
		{
			return map.RemoveEntry(entryOrNull);
		}
		return map;
	}
}
