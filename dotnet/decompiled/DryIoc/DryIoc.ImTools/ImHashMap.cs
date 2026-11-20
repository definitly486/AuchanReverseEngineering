using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace DryIoc.ImTools;

public class ImHashMap<K, V>
{
	public delegate ImHashMapEntry<K, V> UpdaterOrKeeper<S>(S state, ImHashMapEntry<K, V> oldEntry, ImHashMapEntry<K, V> newEntry);

	public abstract class Entry : ImHashMap<K, V>
	{
		public readonly int Hash;

		protected Entry(int hash)
		{
			Hash = hash;
		}

		internal override Entry GetMinHashEntryOrDefault()
		{
			return this;
		}

		internal override Entry GetMaxHashEntryOrDefault()
		{
			return this;
		}

		internal sealed override Entry GetEntryOrNull(int hash)
		{
			if (hash != Hash)
			{
				return null;
			}
			return this;
		}

		public abstract ImHashMapEntry<K, V> GetEntryOrNull(int hash, K key);

		public abstract Entry Update(ImHashMapEntry<K, V> newEntry);

		public abstract Entry UpdateOrKeep<S>(S state, ImHashMapEntry<K, V> newEntry, UpdaterOrKeeper<S> updateOrKeep);

		public sealed override ImHashMap<K, V> AddOrGetEntry(int hash, Entry entry)
		{
			if (hash <= Hash)
			{
				if (hash >= Hash)
				{
					return this;
				}
				return new Leaf2(entry, this);
			}
			return new Leaf2(this, entry);
		}

		internal sealed override ImHashMap<K, V> ReplaceEntry(int hash, Entry oldEntry, Entry newEntry)
		{
			return newEntry;
		}

		internal sealed override ImHashMap<K, V> RemoveEntry(Entry removedEntry)
		{
			return Empty;
		}
	}

	internal sealed class Leaf2 : ImHashMap<K, V>
	{
		public readonly Entry Entry0;

		public readonly Entry Entry1;

		public Leaf2(Entry e0, Entry e1)
		{
			Entry0 = e0;
			Entry1 = e1;
		}

		public override int Count()
		{
			return Entry0.Count() + Entry1.Count();
		}

		public override string ToString()
		{
			return "{L2:{E0:" + Entry0?.ToString() + ",E1:" + Entry1?.ToString() + "}}";
		}

		internal override Entry GetMinHashEntryOrDefault()
		{
			return Entry0;
		}

		internal override Entry GetMaxHashEntryOrDefault()
		{
			return Entry1;
		}

		internal override Entry GetEntryOrNull(int hash)
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

		public override ImHashMap<K, V> AddOrGetEntry(int hash, Entry entry)
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

		internal override ImHashMap<K, V> ReplaceEntry(int hash, Entry oldEntry, Entry newEntry)
		{
			if (oldEntry != Entry0)
			{
				return new Leaf2(Entry0, newEntry);
			}
			return new Leaf2(newEntry, Entry1);
		}

		internal override ImHashMap<K, V> RemoveEntry(Entry removedEntry)
		{
			if (Entry0 != removedEntry)
			{
				return Entry0;
			}
			return Entry1;
		}
	}

	internal sealed class Leaf2Plus1 : ImHashMap<K, V>
	{
		public readonly Entry Plus;

		public readonly Leaf2 L;

		public Leaf2Plus1(Entry plus, Leaf2 leaf)
		{
			Plus = plus;
			L = leaf;
		}

		public override int Count()
		{
			return Plus.Count() + L.Entry0.Count() + L.Entry1.Count();
		}

		public override string ToString()
		{
			return "{L21:{P:" + Plus?.ToString() + ",L:" + L?.ToString() + "}}";
		}

		internal sealed override Entry GetMinHashEntryOrDefault()
		{
			if (Plus.Hash >= L.Entry0.Hash)
			{
				return L.Entry0;
			}
			return Plus;
		}

		internal sealed override Entry GetMaxHashEntryOrDefault()
		{
			if (Plus.Hash <= L.Entry1.Hash)
			{
				return L.Entry1;
			}
			return Plus;
		}

		internal override Entry GetEntryOrNull(int hash)
		{
			if (hash == Plus.Hash)
			{
				return Plus;
			}
			Entry entry = L.Entry0;
			Entry entry2 = L.Entry1;
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

		public sealed override ImHashMap<K, V> AddOrGetEntry(int hash, Entry entry)
		{
			if (hash == Plus.Hash)
			{
				return Plus;
			}
			Entry entry2 = L.Entry0;
			Entry entry3 = L.Entry1;
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

		internal sealed override ImHashMap<K, V> ReplaceEntry(int hash, Entry oldEntry, Entry newEntry)
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

		internal override ImHashMap<K, V> RemoveEntry(Entry removedEntry)
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

	internal sealed class Leaf2Plus1Plus1 : ImHashMap<K, V>
	{
		public readonly Entry Plus;

		public readonly Leaf2Plus1 L;

		public Leaf2Plus1Plus1(Entry plus, Leaf2Plus1 l)
		{
			Plus = plus;
			L = l;
		}

		public override int Count()
		{
			return Plus.Count() + L.Plus.Count() + L.L.Entry0.Count() + L.L.Entry1.Count();
		}

		public override string ToString()
		{
			return "{L211:{P:" + Plus?.ToString() + ", L:" + L?.ToString() + "}}";
		}

		internal sealed override Entry GetMinHashEntryOrDefault()
		{
			Entry minHashEntryOrDefault = L.GetMinHashEntryOrDefault();
			if (Plus.Hash >= minHashEntryOrDefault.Hash)
			{
				return minHashEntryOrDefault;
			}
			return Plus;
		}

		internal sealed override Entry GetMaxHashEntryOrDefault()
		{
			Entry maxHashEntryOrDefault = L.GetMaxHashEntryOrDefault();
			if (Plus.Hash <= maxHashEntryOrDefault.Hash)
			{
				return maxHashEntryOrDefault;
			}
			return Plus;
		}

		internal override Entry GetEntryOrNull(int hash)
		{
			if (hash == Plus.Hash)
			{
				return Plus;
			}
			if (hash == L.Plus.Hash)
			{
				return L.Plus;
			}
			Entry entry = L.L.Entry0;
			Entry entry2 = L.L.Entry1;
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

		public sealed override ImHashMap<K, V> AddOrGetEntry(int hash, Entry entry)
		{
			Entry a = Plus;
			int hash2 = a.Hash;
			if (hash2 == hash)
			{
				return a;
			}
			Entry b = L.Plus;
			int hash3 = b.Hash;
			if (hash3 == hash)
			{
				return b;
			}
			Leaf2 l = L.L;
			Entry a2 = l.Entry0;
			Entry a3 = l.Entry1;
			if (hash == a2.Hash)
			{
				return a2;
			}
			if (hash == a3.Hash)
			{
				return a3;
			}
			if (hash3 < a3.Hash)
			{
				Fun.Swap(ref a3, ref b);
				if (hash3 < a2.Hash)
				{
					Fun.Swap(ref a2, ref a3);
				}
			}
			if (hash2 < b.Hash)
			{
				Fun.Swap(ref a, ref b);
				if (hash2 < a3.Hash)
				{
					Fun.Swap(ref b, ref a3);
					if (hash2 < a2.Hash)
					{
						Fun.Swap(ref a3, ref a2);
					}
				}
			}
			Entry a4 = entry;
			if (hash < a.Hash)
			{
				Fun.Swap(ref a4, ref a);
				if (hash < b.Hash)
				{
					Fun.Swap(ref a, ref b);
					if (hash < a3.Hash)
					{
						Fun.Swap(ref b, ref a3);
						if (hash < a2.Hash)
						{
							Fun.Swap(ref a3, ref a2);
						}
					}
				}
			}
			return new Leaf5(a2, a3, b, a, a4);
		}

		internal sealed override ImHashMap<K, V> ReplaceEntry(int hash, Entry oldEntry, Entry newEntry)
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

		internal override ImHashMap<K, V> RemoveEntry(Entry removedEntry)
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

	internal sealed class Leaf5 : ImHashMap<K, V>
	{
		public readonly Entry Entry0;

		public readonly Entry Entry1;

		public readonly Entry Entry2;

		public readonly Entry Entry3;

		public readonly Entry Entry4;

		public Leaf5(Entry e0, Entry e1, Entry e2, Entry e3, Entry e4)
		{
			Entry0 = e0;
			Entry1 = e1;
			Entry2 = e2;
			Entry3 = e3;
			Entry4 = e4;
		}

		public override int Count()
		{
			return Entry0.Count() + Entry1.Count() + Entry2.Count() + Entry3.Count() + Entry4.Count();
		}

		public override string ToString()
		{
			return "{L2:{E0:" + Entry0?.ToString() + ", E1:" + Entry1?.ToString() + ", E2:" + Entry2?.ToString() + ",E3:" + Entry3?.ToString() + ",E4:" + Entry4?.ToString() + "}}";
		}

		internal sealed override Entry GetMinHashEntryOrDefault()
		{
			return Entry0;
		}

		internal sealed override Entry GetMaxHashEntryOrDefault()
		{
			return Entry4;
		}

		internal override Entry GetEntryOrNull(int hash)
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

		public sealed override ImHashMap<K, V> AddOrGetEntry(int hash, Entry entry)
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

		internal sealed override ImHashMap<K, V> ReplaceEntry(int hash, Entry oldEntry, Entry newEntry)
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

		internal override ImHashMap<K, V> RemoveEntry(Entry removedEntry)
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

	internal sealed class Leaf5Plus1 : ImHashMap<K, V>
	{
		public readonly Entry Plus;

		public readonly Leaf5 L;

		public Leaf5Plus1(Entry plus, Leaf5 l)
		{
			Plus = plus;
			L = l;
		}

		public override int Count()
		{
			return Plus.Count() + L.Count();
		}

		public override string ToString()
		{
			return "{L51:{P:" + Plus?.ToString() + ",L:" + L?.ToString() + "}}";
		}

		internal sealed override Entry GetMinHashEntryOrDefault()
		{
			if (Plus.Hash >= L.Entry0.Hash)
			{
				return L.Entry0;
			}
			return Plus;
		}

		internal sealed override Entry GetMaxHashEntryOrDefault()
		{
			if (Plus.Hash <= L.Entry4.Hash)
			{
				return L.Entry4;
			}
			return Plus;
		}

		internal override Entry GetEntryOrNull(int hash)
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

		public sealed override ImHashMap<K, V> AddOrGetEntry(int hash, Entry entry)
		{
			Entry plus = Plus;
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

		internal sealed override ImHashMap<K, V> ReplaceEntry(int hash, Entry oldEntry, Entry newEntry)
		{
			Entry plus = Plus;
			if (oldEntry == plus)
			{
				return new Leaf5Plus1(newEntry, L);
			}
			Leaf5 l = L;
			Entry entry = l.Entry0;
			Entry entry2 = l.Entry1;
			Entry entry3 = l.Entry2;
			Entry entry4 = l.Entry3;
			Entry entry5 = l.Entry4;
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

		internal override ImHashMap<K, V> RemoveEntry(Entry removedEntry)
		{
			Entry entry = Plus;
			if (entry == removedEntry)
			{
				return L;
			}
			int hash = entry.Hash;
			Leaf5 l = L;
			Entry entry2 = l.Entry0;
			Entry entry3 = l.Entry1;
			Entry entry4 = l.Entry2;
			Entry entry5 = l.Entry3;
			Entry entry6 = l.Entry4;
			Entry entry7 = null;
			if (hash < entry6.Hash)
			{
				entry7 = entry6;
				entry6 = entry;
				entry = entry7;
				if (hash < entry5.Hash)
				{
					entry7 = entry5;
					entry5 = entry6;
					entry6 = entry7;
					if (hash < entry4.Hash)
					{
						entry7 = entry4;
						entry4 = entry5;
						entry5 = entry7;
						if (hash < entry3.Hash)
						{
							entry7 = entry3;
							entry3 = entry4;
							entry4 = entry7;
							if (hash < entry2.Hash)
							{
								entry7 = entry2;
								entry2 = entry3;
								entry3 = entry7;
							}
						}
					}
				}
			}
			if (removedEntry != entry2)
			{
				if (removedEntry != entry3)
				{
					if (removedEntry != entry4)
					{
						if (removedEntry != entry5)
						{
							if (removedEntry != entry6)
							{
								return new Leaf5(entry2, entry3, entry4, entry5, entry6);
							}
							return new Leaf5(entry2, entry3, entry4, entry5, entry);
						}
						return new Leaf5(entry2, entry3, entry4, entry6, entry);
					}
					return new Leaf5(entry2, entry3, entry5, entry6, entry);
				}
				return new Leaf5(entry2, entry4, entry5, entry6, entry);
			}
			return new Leaf5(entry3, entry4, entry5, entry6, entry);
		}
	}

	internal abstract class OnTheVergeOfBalance : ImHashMap<K, V>
	{
		internal abstract ImHashMap<K, V> AddOrGetEntry(int hash, ref Entry entry, ref ImHashMap<K, V> splitRight);
	}

	internal sealed class Leaf5Plus1Plus1 : OnTheVergeOfBalance
	{
		public readonly Entry Plus;

		public readonly Leaf5Plus1 L;

		public Leaf5Plus1Plus1(Entry plus, Leaf5Plus1 l)
		{
			Plus = plus;
			L = l;
		}

		public override int Count()
		{
			return Plus.Count() + L.Count();
		}

		public override string ToString()
		{
			return "{L511:{P:" + Plus?.ToString() + ",L:" + L?.ToString() + "}}";
		}

		internal sealed override Entry GetMinHashEntryOrDefault()
		{
			Entry minHashEntryOrDefault = L.GetMinHashEntryOrDefault();
			if (Plus.Hash >= minHashEntryOrDefault.Hash)
			{
				return minHashEntryOrDefault;
			}
			return Plus;
		}

		internal sealed override Entry GetMaxHashEntryOrDefault()
		{
			Entry maxHashEntryOrDefault = L.GetMaxHashEntryOrDefault();
			if (Plus.Hash <= maxHashEntryOrDefault.Hash)
			{
				return maxHashEntryOrDefault;
			}
			return Plus;
		}

		internal override Entry GetEntryOrNull(int hash)
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

		public override ImHashMap<K, V> AddOrGetEntry(int hash, Entry entry)
		{
			ImHashMap<K, V> splitRight = null;
			ImHashMap<K, V> imHashMap = AddOrGetEntry(hash, ref entry, ref splitRight);
			if (splitRight != null)
			{
				return new Branch2(imHashMap, entry, splitRight);
			}
			return imHashMap;
		}

		internal override ImHashMap<K, V> AddOrGetEntry(int hash, ref Entry entry, ref ImHashMap<K, V> splitRight)
		{
			Entry entry2 = Plus;
			int hash2 = entry2.Hash;
			if (hash2 == hash)
			{
				return entry2;
			}
			Entry entry3 = L.Plus;
			int hash3 = entry3.Hash;
			if (hash3 == hash)
			{
				return entry3;
			}
			Leaf5 l = L.L;
			Entry entry4 = l.Entry0;
			Entry entry5 = l.Entry1;
			Entry entry6 = l.Entry2;
			Entry entry7 = l.Entry3;
			Entry entry8 = l.Entry4;
			if (hash == entry4.Hash)
			{
				return entry4;
			}
			if (hash == entry5.Hash)
			{
				return entry5;
			}
			if (hash == entry6.Hash)
			{
				return entry6;
			}
			if (hash == entry7.Hash)
			{
				return entry7;
			}
			if (hash == entry8.Hash)
			{
				return entry8;
			}
			bool flag = hash > entry8.Hash && hash2 > entry8.Hash && hash3 > entry8.Hash;
			bool flag2 = !flag && hash < entry4.Hash && hash2 < entry4.Hash && hash3 < entry4.Hash;
			Entry entry9 = null;
			if (hash3 < entry8.Hash)
			{
				entry9 = entry8;
				entry8 = entry3;
				entry3 = entry9;
				if (hash3 < entry7.Hash)
				{
					entry9 = entry7;
					entry7 = entry8;
					entry8 = entry9;
					if (hash3 < entry6.Hash)
					{
						entry9 = entry6;
						entry6 = entry7;
						entry7 = entry9;
						if (hash3 < entry5.Hash)
						{
							entry9 = entry5;
							entry5 = entry6;
							entry6 = entry9;
							if (hash3 < entry4.Hash)
							{
								entry9 = entry4;
								entry4 = entry5;
								entry5 = entry9;
							}
						}
					}
				}
			}
			if (hash2 < entry3.Hash)
			{
				entry9 = entry3;
				entry3 = entry2;
				entry2 = entry9;
				if (hash2 < entry8.Hash)
				{
					entry9 = entry8;
					entry8 = entry3;
					entry3 = entry9;
					if (hash2 < entry7.Hash)
					{
						entry9 = entry7;
						entry7 = entry8;
						entry8 = entry9;
						if (hash2 < entry6.Hash)
						{
							entry9 = entry6;
							entry6 = entry7;
							entry7 = entry9;
							if (hash2 < entry5.Hash)
							{
								entry9 = entry5;
								entry5 = entry6;
								entry6 = entry9;
								if (hash2 < entry4.Hash)
								{
									entry9 = entry4;
									entry4 = entry5;
									entry5 = entry9;
								}
							}
						}
					}
				}
			}
			Entry entry10 = entry;
			if (hash < entry2.Hash)
			{
				entry9 = entry2;
				entry2 = entry10;
				entry10 = entry9;
				if (hash < entry3.Hash)
				{
					entry9 = entry3;
					entry3 = entry2;
					entry2 = entry9;
					if (hash < entry8.Hash)
					{
						entry9 = entry8;
						entry8 = entry3;
						entry3 = entry9;
						if (hash < entry7.Hash)
						{
							entry9 = entry7;
							entry7 = entry8;
							entry8 = entry9;
							if (hash < entry6.Hash)
							{
								entry9 = entry6;
								entry6 = entry7;
								entry7 = entry9;
								if (hash < entry5.Hash)
								{
									entry9 = entry5;
									entry5 = entry6;
									entry6 = entry9;
									if (hash < entry4.Hash)
									{
										entry9 = entry4;
										entry4 = entry5;
										entry5 = entry9;
									}
								}
							}
						}
					}
				}
			}
			if (flag2)
			{
				entry = entry6;
				splitRight = l;
				return new Leaf2(entry4, entry5);
			}
			entry = entry3;
			splitRight = new Leaf2(entry2, entry10);
			if (!flag)
			{
				return new Leaf5(entry4, entry5, entry6, entry7, entry8);
			}
			return l;
		}

		internal sealed override ImHashMap<K, V> ReplaceEntry(int hash, Entry oldEntry, Entry newEntry)
		{
			Entry plus = Plus;
			if (plus == oldEntry)
			{
				return new Leaf5Plus1Plus1(newEntry, L);
			}
			Entry plus2 = L.Plus;
			if (plus2 == oldEntry)
			{
				return new Leaf5Plus1Plus1(plus, new Leaf5Plus1(newEntry, L.L));
			}
			Leaf5 l = L.L;
			Entry entry = l.Entry0;
			Entry entry2 = l.Entry1;
			Entry entry3 = l.Entry2;
			Entry entry4 = l.Entry3;
			Entry entry5 = l.Entry4;
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

		internal override ImHashMap<K, V> RemoveEntry(Entry removedEntry)
		{
			Entry entry = Plus;
			if (entry == removedEntry)
			{
				return L;
			}
			Entry entry2 = L.Plus;
			if (entry2 == removedEntry)
			{
				return new Leaf5Plus1(entry, L.L);
			}
			Leaf5 l = L.L;
			Entry entry3 = l.Entry0;
			Entry entry4 = l.Entry1;
			Entry entry5 = l.Entry2;
			Entry entry6 = l.Entry3;
			Entry entry7 = l.Entry4;
			Entry entry8 = null;
			int hash = entry2.Hash;
			int hash2 = entry.Hash;
			if (hash < entry7.Hash)
			{
				entry8 = entry7;
				entry7 = entry2;
				entry2 = entry8;
				if (hash < entry6.Hash)
				{
					entry8 = entry6;
					entry6 = entry7;
					entry7 = entry8;
					if (hash < entry5.Hash)
					{
						entry8 = entry5;
						entry5 = entry6;
						entry6 = entry8;
						if (hash < entry4.Hash)
						{
							entry8 = entry4;
							entry4 = entry5;
							entry5 = entry8;
							if (hash < entry3.Hash)
							{
								entry8 = entry3;
								entry3 = entry4;
								entry4 = entry8;
							}
						}
					}
				}
			}
			if (hash2 < entry2.Hash)
			{
				entry8 = entry2;
				entry2 = entry;
				entry = entry8;
				if (hash2 < entry7.Hash)
				{
					entry8 = entry7;
					entry7 = entry2;
					entry2 = entry8;
					if (hash2 < entry6.Hash)
					{
						entry8 = entry6;
						entry6 = entry7;
						entry7 = entry8;
						if (hash2 < entry5.Hash)
						{
							entry8 = entry5;
							entry5 = entry6;
							entry6 = entry8;
							if (hash2 < entry4.Hash)
							{
								entry8 = entry4;
								entry4 = entry5;
								entry5 = entry8;
								if (hash2 < entry3.Hash)
								{
									entry8 = entry3;
									entry3 = entry4;
									entry4 = entry8;
								}
							}
						}
					}
				}
			}
			if (removedEntry != entry3)
			{
				if (removedEntry != entry4)
				{
					if (removedEntry != entry5)
					{
						if (removedEntry != entry6)
						{
							if (removedEntry != entry7)
							{
								if (removedEntry != entry2)
								{
									return new Leaf5Plus1(entry2, new Leaf5(entry3, entry4, entry5, entry6, entry7));
								}
								return new Leaf5Plus1(entry, new Leaf5(entry3, entry4, entry5, entry6, entry7));
							}
							return new Leaf5Plus1(entry, new Leaf5(entry3, entry4, entry5, entry6, entry2));
						}
						return new Leaf5Plus1(entry, new Leaf5(entry3, entry4, entry5, entry7, entry2));
					}
					return new Leaf5Plus1(entry, new Leaf5(entry3, entry4, entry6, entry7, entry2));
				}
				return new Leaf5Plus1(entry, new Leaf5(entry3, entry5, entry6, entry7, entry2));
			}
			return new Leaf5Plus1(entry, new Leaf5(entry4, entry5, entry6, entry7, entry2));
		}
	}

	internal sealed class Branch2 : ImHashMap<K, V>
	{
		public readonly ImHashMap<K, V> Left;

		public readonly Entry MidEntry;

		public readonly ImHashMap<K, V> Right;

		public Branch2(ImHashMap<K, V> left, Entry entry, ImHashMap<K, V> right)
		{
			MidEntry = entry;
			Left = left;
			Right = right;
		}

		public override int Count()
		{
			return MidEntry.Count() + Left.Count() + Right.Count();
		}

		public override string ToString()
		{
			return "{B2:{E:" + MidEntry?.ToString() + ",L:" + Left?.ToString() + ",R:" + Right?.ToString() + "}}";
		}

		internal override Entry GetMinHashEntryOrDefault()
		{
			return Left.GetMinHashEntryOrDefault();
		}

		internal override Entry GetMaxHashEntryOrDefault()
		{
			return Right.GetMaxHashEntryOrDefault();
		}

		internal override Entry GetEntryOrNull(int hash)
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

		public override ImHashMap<K, V> AddOrGetEntry(int hash, Entry entry)
		{
			Entry midEntry = MidEntry;
			ImHashMap<K, V> imHashMap = null;
			if (hash > midEntry.Hash)
			{
				ImHashMap<K, V> right = Right;
				if (right is OnTheVergeOfBalance onTheVergeOfBalance)
				{
					ImHashMap<K, V> splitRight = null;
					imHashMap = onTheVergeOfBalance.AddOrGetEntry(hash, ref entry, ref splitRight);
					if (splitRight != null)
					{
						return new Branch3(Left, midEntry, imHashMap, entry, splitRight);
					}
				}
				else
				{
					imHashMap = right.AddOrGetEntry(hash, entry);
				}
				if (!(imHashMap is Entry))
				{
					return new Branch2(Left, midEntry, imHashMap);
				}
				return imHashMap;
			}
			if (hash < midEntry.Hash)
			{
				ImHashMap<K, V> left = Left;
				if (left is OnTheVergeOfBalance onTheVergeOfBalance2)
				{
					ImHashMap<K, V> splitRight2 = null;
					imHashMap = onTheVergeOfBalance2.AddOrGetEntry(hash, ref entry, ref splitRight2);
					if (splitRight2 != null)
					{
						return new Branch3(imHashMap, entry, splitRight2, midEntry, Right);
					}
				}
				else
				{
					imHashMap = left.AddOrGetEntry(hash, entry);
				}
				if (!(imHashMap is Entry))
				{
					return new Branch2(imHashMap, midEntry, Right);
				}
				return imHashMap;
			}
			return midEntry;
		}

		internal override ImHashMap<K, V> ReplaceEntry(int hash, Entry oldEntry, Entry newEntry)
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

		internal override ImHashMap<K, V> RemoveEntry(Entry removedEntry)
		{
			Entry entry = MidEntry;
			if (removedEntry.Hash > entry.Hash)
			{
				ImHashMap<K, V> imHashMap = Right.RemoveEntry(removedEntry);
				if (imHashMap == Empty)
				{
					if (!(Left is Leaf5Plus1Plus1))
					{
						return Left.AddOrGetEntry(entry.Hash, entry);
					}
					return new Branch2(Left.RemoveEntry(removedEntry = Left.GetMaxHashEntryOrDefault()), removedEntry, entry);
				}
				if (Right is Branch2 && !(imHashMap is Branch2))
				{
					if (Left is Branch3 branch)
					{
						return new Branch2(new Branch2(branch.Left, branch.Entry0, branch.Middle), branch.Entry1, new Branch2(branch.Right, entry, imHashMap));
					}
					Branch2 branch2 = (Branch2)Left;
					return new Branch3(branch2.Left, branch2.MidEntry, branch2.Right, entry, imHashMap);
				}
				return new Branch2(Left, entry, imHashMap);
			}
			if (removedEntry == entry)
			{
				removedEntry = (entry = Left.GetMaxHashEntryOrDefault());
			}
			ImHashMap<K, V> imHashMap2 = Left.RemoveEntry(removedEntry);
			if (imHashMap2 == Empty)
			{
				if (!(Right is Leaf5Plus1Plus1))
				{
					return Right.AddOrGetEntry(entry.Hash, entry);
				}
				return new Branch2(entry, removedEntry = Right.GetMinHashEntryOrDefault(), Right.RemoveEntry(removedEntry));
			}
			if (Left is Branch2 && !(imHashMap2 is Branch2))
			{
				if (Right is Branch3 branch3)
				{
					return new Branch2(new Branch2(imHashMap2, entry, branch3.Left), branch3.Entry0, new Branch2(branch3.Middle, branch3.Entry1, branch3.Right));
				}
				Branch2 branch4 = (Branch2)Right;
				return new Branch3(imHashMap2, entry, branch4.Left, branch4.MidEntry, branch4.Right);
			}
			return new Branch2(imHashMap2, entry, Right);
		}
	}

	internal sealed class Branch3 : OnTheVergeOfBalance
	{
		public readonly Entry Entry0;

		public readonly Entry Entry1;

		public readonly ImHashMap<K, V> Left;

		public readonly ImHashMap<K, V> Middle;

		public readonly ImHashMap<K, V> Right;

		public Branch3(ImHashMap<K, V> left, Entry e0, ImHashMap<K, V> middle, Entry e1, ImHashMap<K, V> right)
		{
			Left = left;
			Entry0 = e0;
			Middle = middle;
			Entry1 = e1;
			Right = right;
		}

		public override int Count()
		{
			return Entry0.Count() + Entry1.Count() + Left.Count() + Middle.Count() + Right.Count();
		}

		public override string ToString()
		{
			return "{B3:{E0:" + Entry0?.ToString() + ",E1:" + Entry0?.ToString() + ",L:" + Left?.ToString() + ",M:" + Middle?.ToString() + ",R:" + Right?.ToString() + "}}";
		}

		internal override Entry GetMinHashEntryOrDefault()
		{
			return Left.GetMinHashEntryOrDefault();
		}

		internal override Entry GetMaxHashEntryOrDefault()
		{
			return Right.GetMaxHashEntryOrDefault();
		}

		internal override Entry GetEntryOrNull(int hash)
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

		public override ImHashMap<K, V> AddOrGetEntry(int hash, Entry entry)
		{
			int hash2 = Entry1.Hash;
			if (hash > hash2)
			{
				ImHashMap<K, V> right = Right;
				ImHashMap<K, V> imHashMap = right.AddOrGetEntry(hash, entry);
				if (imHashMap is Entry)
				{
					return imHashMap;
				}
				if (right is OnTheVergeOfBalance && imHashMap is Branch2)
				{
					return new Branch2(new Branch2(Left, Entry0, Middle), Entry1, imHashMap);
				}
				return new Branch3(Left, Entry0, Middle, Entry1, imHashMap);
			}
			int hash3 = Entry0.Hash;
			if (hash < hash3)
			{
				ImHashMap<K, V> left = Left;
				ImHashMap<K, V> imHashMap2 = left.AddOrGetEntry(hash, entry);
				if (imHashMap2 is Entry)
				{
					return imHashMap2;
				}
				if (left is OnTheVergeOfBalance && imHashMap2 is Branch2)
				{
					return new Branch2(imHashMap2, Entry0, new Branch2(Middle, Entry1, Right));
				}
				return new Branch3(imHashMap2, Entry0, Middle, Entry1, Right);
			}
			if (hash > hash3 && hash < hash2)
			{
				ImHashMap<K, V> middle = Middle;
				ImHashMap<K, V> imHashMap3 = null;
				if (middle is OnTheVergeOfBalance onTheVergeOfBalance)
				{
					ImHashMap<K, V> splitRight = null;
					imHashMap3 = onTheVergeOfBalance.AddOrGetEntry(hash, ref entry, ref splitRight);
					if (splitRight != null)
					{
						return new Branch2(new Branch2(Left, Entry0, imHashMap3), entry, new Branch2(splitRight, Entry1, Right));
					}
				}
				else
				{
					imHashMap3 = middle.AddOrGetEntry(hash, entry);
				}
				if (!(imHashMap3 is Entry))
				{
					return new Branch3(Left, Entry0, imHashMap3, Entry1, Right);
				}
				return imHashMap3;
			}
			if (hash != hash3)
			{
				return Entry1;
			}
			return Entry0;
		}

		internal override ImHashMap<K, V> AddOrGetEntry(int hash, ref Entry entry, ref ImHashMap<K, V> splitRight)
		{
			int hash2 = Entry1.Hash;
			if (hash > hash2)
			{
				ImHashMap<K, V> right = Right;
				ImHashMap<K, V> imHashMap = right.AddOrGetEntry(hash, entry);
				if (imHashMap is Entry)
				{
					return imHashMap;
				}
				if (right is OnTheVergeOfBalance && imHashMap is Branch2)
				{
					entry = Entry1;
					splitRight = imHashMap;
					return new Branch2(Left, Entry0, Middle);
				}
				return new Branch3(Left, Entry0, Middle, Entry1, imHashMap);
			}
			int hash3 = Entry0.Hash;
			if (hash < hash3)
			{
				ImHashMap<K, V> left = Left;
				ImHashMap<K, V> imHashMap2 = left.AddOrGetEntry(hash, entry);
				if (imHashMap2 is Entry)
				{
					return imHashMap2;
				}
				if (left is OnTheVergeOfBalance && imHashMap2 is Branch2)
				{
					entry = Entry0;
					splitRight = new Branch2(Middle, Entry1, Right);
					return imHashMap2;
				}
				return new Branch3(imHashMap2, Entry0, Middle, Entry1, Right);
			}
			if (hash > hash3 && hash < hash2)
			{
				ImHashMap<K, V> middle = Middle;
				ImHashMap<K, V> imHashMap3 = null;
				if (middle is OnTheVergeOfBalance onTheVergeOfBalance)
				{
					ImHashMap<K, V> splitRight2 = null;
					imHashMap3 = onTheVergeOfBalance.AddOrGetEntry(hash, ref entry, ref splitRight2);
					if (splitRight2 != null)
					{
						splitRight = new Branch2(splitRight2, Entry1, Right);
						return new Branch2(Left, Entry0, imHashMap3);
					}
				}
				else
				{
					imHashMap3 = middle.AddOrGetEntry(hash, entry);
				}
				if (imHashMap3 is Entry)
				{
					return imHashMap3;
				}
				return new Branch3(Left, Entry0, imHashMap3, Entry1, Right);
			}
			if (hash != hash3)
			{
				return Entry1;
			}
			return Entry0;
		}

		internal override ImHashMap<K, V> ReplaceEntry(int hash, Entry oldEntry, Entry newEntry)
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

		internal override ImHashMap<K, V> RemoveEntry(Entry removedEntry)
		{
			Entry entry = Entry0;
			ImHashMap<K, V> middle = Middle;
			Entry entry2 = Entry1;
			ImHashMap<K, V> right = Right;
			if (removedEntry == entry)
			{
				removedEntry = (entry = Left.GetMaxHashEntryOrDefault());
			}
			if (removedEntry.Hash <= entry.Hash)
			{
				ImHashMap<K, V> imHashMap = Left.RemoveEntry(removedEntry);
				if (imHashMap == Empty)
				{
					if (!(middle is Leaf5Plus1Plus1))
					{
						return new Branch2(middle.AddOrGetEntry(entry.Hash, entry), entry2, right);
					}
					return new Branch3(entry, removedEntry = middle.GetMinHashEntryOrDefault(), middle.RemoveEntry(removedEntry), entry2, right);
				}
				if (Left is Branch2 && !(imHashMap is Branch2))
				{
					if (middle is Branch3 branch)
					{
						return new Branch3(new Branch2(imHashMap, entry, branch.Left), branch.Entry0, new Branch2(branch.Middle, branch.Entry1, branch.Right), entry2, right);
					}
					Branch2 branch2 = (Branch2)middle;
					return new Branch2(new Branch3(imHashMap, entry, branch2.Left, branch2.MidEntry, branch2.Right), entry2, right);
				}
				return new Branch3(imHashMap, entry, middle, entry2, right);
			}
			if (removedEntry == entry2)
			{
				removedEntry = (entry2 = middle.GetMaxHashEntryOrDefault());
			}
			if (removedEntry.Hash <= entry2.Hash)
			{
				ImHashMap<K, V> imHashMap2 = middle.RemoveEntry(removedEntry);
				if (imHashMap2 == Empty)
				{
					if (!(right is Leaf5Plus1Plus1))
					{
						return new Branch2(Left, entry, right.AddOrGetEntry(entry2.Hash, entry2));
					}
					return new Branch3(Left, entry, entry2, removedEntry = right.GetMinHashEntryOrDefault(), right.RemoveEntry(removedEntry));
				}
				if (middle is Branch2 && !(imHashMap2 is Branch2))
				{
					if (right is Branch3 branch3)
					{
						return new Branch3(Left, entry, new Branch2(imHashMap2, entry2, branch3.Left), branch3.Entry0, new Branch2(branch3.Middle, branch3.Entry1, branch3.Right));
					}
					Branch2 branch4 = (Branch2)right;
					return new Branch2(Left, entry, new Branch3(imHashMap2, entry2, branch4.Left, branch4.MidEntry, branch4.Right));
				}
				return new Branch3(Left, entry, imHashMap2, entry2, right);
			}
			ImHashMap<K, V> imHashMap3 = right.RemoveEntry(removedEntry);
			if (imHashMap3 == Empty)
			{
				if (!(middle is Leaf5Plus1Plus1))
				{
					return new Branch2(Left, entry, middle.AddOrGetEntry(entry2.Hash, entry2));
				}
				return new Branch3(Left, entry, middle.RemoveEntry(removedEntry = middle.GetMaxHashEntryOrDefault()), removedEntry, entry2);
			}
			if (right is Branch2 && !(imHashMap3 is Branch2))
			{
				if (middle is Branch3 branch5)
				{
					return new Branch3(Left, entry, new Branch2(branch5.Left, branch5.Entry0, branch5.Middle), branch5.Entry1, new Branch2(branch5.Right, entry2, imHashMap3));
				}
				Branch2 branch6 = (Branch2)middle;
				return new Branch2(Left, entry, new Branch3(branch6.Left, branch6.MidEntry, branch6.Right, entry2, imHashMap3));
			}
			return new Branch3(Left, entry, middle, entry2, imHashMap3);
		}
	}

	public static readonly ImHashMap<K, V> Empty = new ImHashMap<K, V>();

	public bool IsEmpty => this == Empty;

	protected ImHashMap()
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

	internal virtual Entry GetMinHashEntryOrDefault()
	{
		return null;
	}

	internal virtual Entry GetMaxHashEntryOrDefault()
	{
		return null;
	}

	internal virtual Entry GetEntryOrNull(int hash)
	{
		return null;
	}

	public virtual ImHashMap<K, V> AddOrGetEntry(int hash, Entry entry)
	{
		return entry;
	}

	internal virtual ImHashMap<K, V> ReplaceEntry(int hash, Entry oldEntry, Entry newEntry)
	{
		return this;
	}

	internal virtual ImHashMap<K, V> RemoveEntry(Entry entry)
	{
		return this;
	}
}
public static class ImHashMap
{
	private static readonly object _enumerationB3Tombstone = new object();

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ImHashMapEntry<K, V> Entry<K, V>(K key, V value)
	{
		return new ImHashMapEntry<K, V>(key.GetHashCode(), key, value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ImHashMapEntry<K, V> Entry<K, V>(int hash, K key, V value)
	{
		return new ImHashMapEntry<K, V>(hash, key, value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static ImHashMap<K, V>.Entry WithConflicting<K, V>(this ImHashMapEntry<K, V> one, ImHashMapEntry<K, V> two)
	{
		return new HashConflictingEntry<K, V>(one.Hash, one, two);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ImHashMapEntry<K, V> SetValue<K, V>(this ImHashMapEntry<K, V> e, V value)
	{
		e.Value = value;
		return e;
	}

	public static IEnumerable<ImHashMapEntry<K, V>> Enumerate<K, V>(this ImHashMap<K, V> map, MapParentStack parents = null)
	{
		if (map == ImHashMap<K, V>.Empty)
		{
			yield break;
		}
		if (map is ImHashMap<K, V>.Entry entry)
		{
			if (entry is ImHashMapEntry<K, V> imHashMapEntry)
			{
				yield return imHashMapEntry;
				yield break;
			}
			ImHashMapEntry<K, V>[] conflicts = ((HashConflictingEntry<K, V>)entry).Conflicts;
			for (int i = 0; i < conflicts.Length; i++)
			{
				yield return conflicts[i];
			}
			yield break;
		}
		int count = 0;
		while (true)
		{
			if (map is ImHashMap<K, V>.Branch2 branch)
			{
				if (parents == null)
				{
					parents = new MapParentStack();
				}
				parents.Put(map, count++);
				map = branch.Left;
				continue;
			}
			if (map is ImHashMap<K, V>.Branch3 branch2)
			{
				if (parents == null)
				{
					parents = new MapParentStack();
				}
				parents.Put(map, count++);
				map = branch2.Left;
				continue;
			}
			if (map is ImHashMap<K, V>.Entry entry2)
			{
				if (entry2 is ImHashMapEntry<K, V> imHashMapEntry2)
				{
					yield return imHashMapEntry2;
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts = ((HashConflictingEntry<K, V>)entry2).Conflicts;
					for (int i = 0; i < conflicts.Length; i++)
					{
						yield return conflicts[i];
					}
				}
			}
			else if (map is ImHashMap<K, V>.Leaf2 l2)
			{
				if (l2.Entry0 is ImHashMapEntry<K, V> imHashMapEntry3)
				{
					yield return imHashMapEntry3;
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts = ((HashConflictingEntry<K, V>)l2.Entry0).Conflicts;
					for (int i = 0; i < conflicts.Length; i++)
					{
						yield return conflicts[i];
					}
				}
				if (l2.Entry1 is ImHashMapEntry<K, V> imHashMapEntry4)
				{
					yield return imHashMapEntry4;
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts = ((HashConflictingEntry<K, V>)l2.Entry1).Conflicts;
					for (int i = 0; i < conflicts.Length; i++)
					{
						yield return conflicts[i];
					}
				}
			}
			else if (map is ImHashMap<K, V>.Leaf2Plus1 { Plus: var p } leaf2Plus)
			{
				int hash = p.Hash;
				ImHashMap<K, V>.Leaf2 l3 = leaf2Plus.L;
				ImHashMap<K, V>.Entry entry3 = l3.Entry0;
				ImHashMap<K, V>.Entry e1 = l3.Entry1;
				if (hash < e1.Hash)
				{
					ImHashMap<K, V>.Entry entry4 = e1;
					e1 = p;
					p = entry4;
					if (hash < entry3.Hash)
					{
						entry4 = entry3;
						entry3 = e1;
						e1 = entry4;
					}
				}
				if (entry3 is ImHashMapEntry<K, V> imHashMapEntry5)
				{
					yield return imHashMapEntry5;
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts = ((HashConflictingEntry<K, V>)entry3).Conflicts;
					for (int i = 0; i < conflicts.Length; i++)
					{
						yield return conflicts[i];
					}
				}
				if (e1 is ImHashMapEntry<K, V> imHashMapEntry6)
				{
					yield return imHashMapEntry6;
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts = ((HashConflictingEntry<K, V>)e1).Conflicts;
					for (int i = 0; i < conflicts.Length; i++)
					{
						yield return conflicts[i];
					}
				}
				if (p is ImHashMapEntry<K, V> imHashMapEntry7)
				{
					yield return imHashMapEntry7;
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts = ((HashConflictingEntry<K, V>)p).Conflicts;
					for (int i = 0; i < conflicts.Length; i++)
					{
						yield return conflicts[i];
					}
				}
			}
			else if (map is ImHashMap<K, V>.Leaf2Plus1Plus1 { Plus: var e2 } leaf2Plus1Plus)
			{
				ImHashMap<K, V>.Entry p2 = leaf2Plus1Plus.L.Plus;
				int hash2 = p2.Hash;
				ImHashMap<K, V>.Leaf2 l4 = leaf2Plus1Plus.L.L;
				ImHashMap<K, V>.Entry entry5 = l4.Entry0;
				ImHashMap<K, V>.Entry e3 = l4.Entry1;
				if (hash2 < e3.Hash)
				{
					ImHashMap<K, V>.Entry entry6 = e3;
					e3 = p2;
					p2 = entry6;
					if (hash2 < entry5.Hash)
					{
						entry6 = entry5;
						entry5 = e3;
						e3 = entry6;
					}
				}
				hash2 = e2.Hash;
				if (hash2 < p2.Hash)
				{
					ImHashMap<K, V>.Entry entry6 = p2;
					p2 = e2;
					e2 = entry6;
					if (hash2 < e3.Hash)
					{
						entry6 = e3;
						e3 = p2;
						p2 = entry6;
						if (hash2 < entry5.Hash)
						{
							entry6 = entry5;
							entry5 = e3;
							e3 = entry6;
						}
					}
				}
				if (entry5 is ImHashMapEntry<K, V> imHashMapEntry8)
				{
					yield return imHashMapEntry8;
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts = ((HashConflictingEntry<K, V>)entry5).Conflicts;
					for (int i = 0; i < conflicts.Length; i++)
					{
						yield return conflicts[i];
					}
				}
				if (e3 is ImHashMapEntry<K, V> imHashMapEntry9)
				{
					yield return imHashMapEntry9;
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts = ((HashConflictingEntry<K, V>)e3).Conflicts;
					for (int i = 0; i < conflicts.Length; i++)
					{
						yield return conflicts[i];
					}
				}
				if (p2 is ImHashMapEntry<K, V> imHashMapEntry10)
				{
					yield return imHashMapEntry10;
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts = ((HashConflictingEntry<K, V>)p2).Conflicts;
					for (int i = 0; i < conflicts.Length; i++)
					{
						yield return conflicts[i];
					}
				}
				if (e2 is ImHashMapEntry<K, V> imHashMapEntry11)
				{
					yield return imHashMapEntry11;
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts = ((HashConflictingEntry<K, V>)e2).Conflicts;
					for (int i = 0; i < conflicts.Length; i++)
					{
						yield return conflicts[i];
					}
				}
			}
			else if (map is ImHashMap<K, V>.Leaf5 l5)
			{
				if (l5.Entry0 is ImHashMapEntry<K, V> imHashMapEntry12)
				{
					yield return imHashMapEntry12;
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts = ((HashConflictingEntry<K, V>)l5.Entry0).Conflicts;
					for (int i = 0; i < conflicts.Length; i++)
					{
						yield return conflicts[i];
					}
				}
				if (l5.Entry1 is ImHashMapEntry<K, V> imHashMapEntry13)
				{
					yield return imHashMapEntry13;
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts = ((HashConflictingEntry<K, V>)l5.Entry1).Conflicts;
					for (int i = 0; i < conflicts.Length; i++)
					{
						yield return conflicts[i];
					}
				}
				if (l5.Entry2 is ImHashMapEntry<K, V> imHashMapEntry14)
				{
					yield return imHashMapEntry14;
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts = ((HashConflictingEntry<K, V>)l5.Entry2).Conflicts;
					for (int i = 0; i < conflicts.Length; i++)
					{
						yield return conflicts[i];
					}
				}
				if (l5.Entry3 is ImHashMapEntry<K, V> imHashMapEntry15)
				{
					yield return imHashMapEntry15;
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts = ((HashConflictingEntry<K, V>)l5.Entry3).Conflicts;
					for (int i = 0; i < conflicts.Length; i++)
					{
						yield return conflicts[i];
					}
				}
				if (l5.Entry4 is ImHashMapEntry<K, V> imHashMapEntry16)
				{
					yield return imHashMapEntry16;
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts = ((HashConflictingEntry<K, V>)l5.Entry4).Conflicts;
					for (int i = 0; i < conflicts.Length; i++)
					{
						yield return conflicts[i];
					}
				}
			}
			else if (map is ImHashMap<K, V>.Leaf5Plus1 { Plus: var e4 } leaf5Plus)
			{
				int hash3 = e4.Hash;
				ImHashMap<K, V>.Leaf5 l6 = leaf5Plus.L;
				ImHashMap<K, V>.Entry entry7 = l6.Entry0;
				ImHashMap<K, V>.Entry p2 = l6.Entry1;
				ImHashMap<K, V>.Entry e1 = l6.Entry2;
				ImHashMap<K, V>.Entry e5 = l6.Entry3;
				ImHashMap<K, V>.Entry e6 = l6.Entry4;
				if (hash3 < e6.Hash)
				{
					ImHashMap<K, V>.Entry entry8 = e6;
					e6 = e4;
					e4 = entry8;
					if (hash3 < e5.Hash)
					{
						entry8 = e5;
						e5 = e6;
						e6 = entry8;
						if (hash3 < e1.Hash)
						{
							entry8 = e1;
							e1 = e5;
							e5 = entry8;
							if (hash3 < p2.Hash)
							{
								entry8 = p2;
								p2 = e1;
								e1 = entry8;
								if (hash3 < entry7.Hash)
								{
									entry8 = entry7;
									entry7 = p2;
									p2 = entry8;
								}
							}
						}
					}
				}
				if (entry7 is ImHashMapEntry<K, V> imHashMapEntry17)
				{
					yield return imHashMapEntry17;
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts = ((HashConflictingEntry<K, V>)entry7).Conflicts;
					for (int i = 0; i < conflicts.Length; i++)
					{
						yield return conflicts[i];
					}
				}
				if (p2 is ImHashMapEntry<K, V> imHashMapEntry18)
				{
					yield return imHashMapEntry18;
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts = ((HashConflictingEntry<K, V>)p2).Conflicts;
					for (int i = 0; i < conflicts.Length; i++)
					{
						yield return conflicts[i];
					}
				}
				if (e1 is ImHashMapEntry<K, V> imHashMapEntry19)
				{
					yield return imHashMapEntry19;
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts = ((HashConflictingEntry<K, V>)e1).Conflicts;
					for (int i = 0; i < conflicts.Length; i++)
					{
						yield return conflicts[i];
					}
				}
				if (e5 is ImHashMapEntry<K, V> imHashMapEntry20)
				{
					yield return imHashMapEntry20;
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts = ((HashConflictingEntry<K, V>)e5).Conflicts;
					for (int i = 0; i < conflicts.Length; i++)
					{
						yield return conflicts[i];
					}
				}
				if (e6 is ImHashMapEntry<K, V> imHashMapEntry21)
				{
					yield return imHashMapEntry21;
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts = ((HashConflictingEntry<K, V>)e6).Conflicts;
					for (int i = 0; i < conflicts.Length; i++)
					{
						yield return conflicts[i];
					}
				}
				if (e4 is ImHashMapEntry<K, V> imHashMapEntry22)
				{
					yield return imHashMapEntry22;
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts = ((HashConflictingEntry<K, V>)e4).Conflicts;
					for (int i = 0; i < conflicts.Length; i++)
					{
						yield return conflicts[i];
					}
				}
			}
			else if (map is ImHashMap<K, V>.Leaf5Plus1Plus1 leaf5Plus1Plus)
			{
				ImHashMap<K, V>.Leaf5 l7 = leaf5Plus1Plus.L.L;
				ImHashMap<K, V>.Entry entry9 = l7.Entry0;
				ImHashMap<K, V>.Entry e6 = l7.Entry1;
				ImHashMap<K, V>.Entry e5 = l7.Entry2;
				ImHashMap<K, V>.Entry e1 = l7.Entry3;
				ImHashMap<K, V>.Entry p2 = l7.Entry4;
				ImHashMap<K, V>.Entry e3 = leaf5Plus1Plus.Plus;
				ImHashMap<K, V>.Entry pp = leaf5Plus1Plus.L.Plus;
				int hash4 = pp.Hash;
				if (hash4 < p2.Hash)
				{
					ImHashMap<K, V>.Entry entry10 = p2;
					p2 = pp;
					pp = entry10;
					if (hash4 < e1.Hash)
					{
						entry10 = e1;
						e1 = p2;
						p2 = entry10;
						if (hash4 < e5.Hash)
						{
							entry10 = e5;
							e5 = e1;
							e1 = entry10;
							if (hash4 < e6.Hash)
							{
								entry10 = e6;
								e6 = e5;
								e5 = entry10;
								if (hash4 < entry9.Hash)
								{
									entry10 = entry9;
									entry9 = e6;
									e6 = entry10;
								}
							}
						}
					}
				}
				hash4 = e3.Hash;
				if (hash4 < pp.Hash)
				{
					ImHashMap<K, V>.Entry entry10 = pp;
					pp = e3;
					e3 = entry10;
					if (hash4 < p2.Hash)
					{
						entry10 = p2;
						p2 = pp;
						pp = entry10;
						if (hash4 < e1.Hash)
						{
							entry10 = e1;
							e1 = p2;
							p2 = entry10;
							if (hash4 < e5.Hash)
							{
								entry10 = e5;
								e5 = e1;
								e1 = entry10;
								if (hash4 < e6.Hash)
								{
									entry10 = e6;
									e6 = e5;
									e5 = entry10;
									if (hash4 < entry9.Hash)
									{
										entry10 = entry9;
										entry9 = e6;
										e6 = entry10;
									}
								}
							}
						}
					}
				}
				if (entry9 is ImHashMapEntry<K, V> imHashMapEntry23)
				{
					yield return imHashMapEntry23;
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts = ((HashConflictingEntry<K, V>)entry9).Conflicts;
					for (int i = 0; i < conflicts.Length; i++)
					{
						yield return conflicts[i];
					}
				}
				if (e6 is ImHashMapEntry<K, V> imHashMapEntry24)
				{
					yield return imHashMapEntry24;
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts = ((HashConflictingEntry<K, V>)e6).Conflicts;
					for (int i = 0; i < conflicts.Length; i++)
					{
						yield return conflicts[i];
					}
				}
				if (e5 is ImHashMapEntry<K, V> imHashMapEntry25)
				{
					yield return imHashMapEntry25;
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts = ((HashConflictingEntry<K, V>)e5).Conflicts;
					for (int i = 0; i < conflicts.Length; i++)
					{
						yield return conflicts[i];
					}
				}
				if (e1 is ImHashMapEntry<K, V> imHashMapEntry26)
				{
					yield return imHashMapEntry26;
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts = ((HashConflictingEntry<K, V>)e1).Conflicts;
					for (int i = 0; i < conflicts.Length; i++)
					{
						yield return conflicts[i];
					}
				}
				if (p2 is ImHashMapEntry<K, V> imHashMapEntry27)
				{
					yield return imHashMapEntry27;
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts = ((HashConflictingEntry<K, V>)p2).Conflicts;
					for (int i = 0; i < conflicts.Length; i++)
					{
						yield return conflicts[i];
					}
				}
				if (pp is ImHashMapEntry<K, V> imHashMapEntry28)
				{
					yield return imHashMapEntry28;
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts = ((HashConflictingEntry<K, V>)pp).Conflicts;
					for (int i = 0; i < conflicts.Length; i++)
					{
						yield return conflicts[i];
					}
				}
				if (e3 is ImHashMapEntry<K, V> imHashMapEntry29)
				{
					yield return imHashMapEntry29;
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts = ((HashConflictingEntry<K, V>)e3).Conflicts;
					for (int i = 0; i < conflicts.Length; i++)
					{
						yield return conflicts[i];
					}
				}
			}
			if (count == 0)
			{
				break;
			}
			MapParentStack mapParentStack = parents;
			int num = count - 1;
			count = num;
			object obj = mapParentStack.Get(num);
			if (obj is ImHashMap<K, V>.Branch2 pb2)
			{
				if (pb2.MidEntry is ImHashMapEntry<K, V> imHashMapEntry30)
				{
					yield return imHashMapEntry30;
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts = ((HashConflictingEntry<K, V>)pb2.MidEntry).Conflicts;
					for (int i = 0; i < conflicts.Length; i++)
					{
						yield return conflicts[i];
					}
				}
				map = pb2.Right;
				continue;
			}
			ImHashMap<K, V>.Branch3 pb3;
			if (obj != _enumerationB3Tombstone)
			{
				pb3 = (ImHashMap<K, V>.Branch3)obj;
				if (pb3.Entry0 is ImHashMapEntry<K, V> imHashMapEntry31)
				{
					yield return imHashMapEntry31;
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts = ((HashConflictingEntry<K, V>)pb3.Entry0).Conflicts;
					for (int i = 0; i < conflicts.Length; i++)
					{
						yield return conflicts[i];
					}
				}
				map = pb3.Middle;
				MapParentStack mapParentStack2 = parents;
				object enumerationB3Tombstone = _enumerationB3Tombstone;
				num = count + 1;
				count = num;
				mapParentStack2.Put(enumerationB3Tombstone, num);
				num = count + 1;
				count = num;
				continue;
			}
			MapParentStack mapParentStack3 = parents;
			num = count - 1;
			count = num;
			pb3 = (ImHashMap<K, V>.Branch3)mapParentStack3.Get(num);
			if (pb3.Entry1 is ImHashMapEntry<K, V> imHashMapEntry32)
			{
				yield return imHashMapEntry32;
			}
			else
			{
				ImHashMapEntry<K, V>[] conflicts = ((HashConflictingEntry<K, V>)pb3.Entry1).Conflicts;
				for (int i = 0; i < conflicts.Length; i++)
				{
					yield return conflicts[i];
				}
			}
			map = pb3.Right;
		}
	}

	public static S ForEach<K, V, S>(this ImHashMap<K, V> map, S state, Action<ImHashMapEntry<K, V>, int, S> handler, MapParentStack parents = null)
	{
		if (map == ImHashMap<K, V>.Empty)
		{
			return state;
		}
		int num = 0;
		if (map is ImHashMap<K, V>.Entry entry)
		{
			if (entry is ImHashMapEntry<K, V> arg)
			{
				handler(arg, 0, state);
			}
			else
			{
				ImHashMapEntry<K, V>[] conflicts = ((HashConflictingEntry<K, V>)entry).Conflicts;
				foreach (ImHashMapEntry<K, V> arg2 in conflicts)
				{
					handler(arg2, num++, state);
				}
			}
			return state;
		}
		int num2 = 0;
		while (true)
		{
			if (map is ImHashMap<K, V>.Branch2 branch)
			{
				if (parents == null)
				{
					parents = new MapParentStack();
				}
				parents.Put(map, num2++);
				map = branch.Left;
				continue;
			}
			if (map is ImHashMap<K, V>.Branch3 branch2)
			{
				if (parents == null)
				{
					parents = new MapParentStack();
				}
				parents.Put(map, num2++);
				map = branch2.Left;
				continue;
			}
			if (map is ImHashMap<K, V>.Entry entry2)
			{
				if (entry2 is ImHashMapEntry<K, V> arg3)
				{
					handler(arg3, num++, state);
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts2 = ((HashConflictingEntry<K, V>)entry2).Conflicts;
					foreach (ImHashMapEntry<K, V> arg4 in conflicts2)
					{
						handler(arg4, num++, state);
					}
				}
			}
			else if (map is ImHashMap<K, V>.Leaf2 leaf)
			{
				if (leaf.Entry0 is ImHashMapEntry<K, V> arg5)
				{
					handler(arg5, num++, state);
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts3 = ((HashConflictingEntry<K, V>)leaf.Entry0).Conflicts;
					foreach (ImHashMapEntry<K, V> arg6 in conflicts3)
					{
						handler(arg6, num++, state);
					}
				}
				if (leaf.Entry1 is ImHashMapEntry<K, V> arg7)
				{
					handler(arg7, num++, state);
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts4 = ((HashConflictingEntry<K, V>)leaf.Entry1).Conflicts;
					foreach (ImHashMapEntry<K, V> arg8 in conflicts4)
					{
						handler(arg8, num++, state);
					}
				}
			}
			else if (map is ImHashMap<K, V>.Leaf2Plus1 { Plus: var entry3 } leaf2Plus)
			{
				int hash = entry3.Hash;
				ImHashMap<K, V>.Leaf2 l2 = leaf2Plus.L;
				ImHashMap<K, V>.Entry entry4 = l2.Entry0;
				ImHashMap<K, V>.Entry entry5 = l2.Entry1;
				ImHashMap<K, V>.Entry entry6 = null;
				if (hash < entry5.Hash)
				{
					entry6 = entry5;
					entry5 = entry3;
					entry3 = entry6;
					if (hash < entry4.Hash)
					{
						entry6 = entry4;
						entry4 = entry5;
						entry5 = entry6;
					}
				}
				if (entry4 is ImHashMapEntry<K, V> arg9)
				{
					handler(arg9, num++, state);
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts5 = ((HashConflictingEntry<K, V>)entry4).Conflicts;
					foreach (ImHashMapEntry<K, V> arg10 in conflicts5)
					{
						handler(arg10, num++, state);
					}
				}
				if (entry5 is ImHashMapEntry<K, V> arg11)
				{
					handler(arg11, num++, state);
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts6 = ((HashConflictingEntry<K, V>)entry5).Conflicts;
					foreach (ImHashMapEntry<K, V> arg12 in conflicts6)
					{
						handler(arg12, num++, state);
					}
				}
				if (entry3 is ImHashMapEntry<K, V> arg13)
				{
					handler(arg13, num++, state);
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts7 = ((HashConflictingEntry<K, V>)entry3).Conflicts;
					foreach (ImHashMapEntry<K, V> arg14 in conflicts7)
					{
						handler(arg14, num++, state);
					}
				}
			}
			else if (map is ImHashMap<K, V>.Leaf2Plus1Plus1 { Plus: var entry7 } leaf2Plus1Plus)
			{
				ImHashMap<K, V>.Entry entry8 = leaf2Plus1Plus.L.Plus;
				int hash2 = entry8.Hash;
				ImHashMap<K, V>.Leaf2 l3 = leaf2Plus1Plus.L.L;
				ImHashMap<K, V>.Entry entry9 = l3.Entry0;
				ImHashMap<K, V>.Entry entry10 = l3.Entry1;
				ImHashMap<K, V>.Entry entry11 = null;
				if (hash2 < entry10.Hash)
				{
					entry11 = entry10;
					entry10 = entry8;
					entry8 = entry11;
					if (hash2 < entry9.Hash)
					{
						entry11 = entry9;
						entry9 = entry10;
						entry10 = entry11;
					}
				}
				hash2 = entry7.Hash;
				if (hash2 < entry8.Hash)
				{
					entry11 = entry8;
					entry8 = entry7;
					entry7 = entry11;
					if (hash2 < entry10.Hash)
					{
						entry11 = entry10;
						entry10 = entry8;
						entry8 = entry11;
						if (hash2 < entry9.Hash)
						{
							entry11 = entry9;
							entry9 = entry10;
							entry10 = entry11;
						}
					}
				}
				if (entry9 is ImHashMapEntry<K, V> arg15)
				{
					handler(arg15, num++, state);
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts8 = ((HashConflictingEntry<K, V>)entry9).Conflicts;
					foreach (ImHashMapEntry<K, V> arg16 in conflicts8)
					{
						handler(arg16, num++, state);
					}
				}
				if (entry10 is ImHashMapEntry<K, V> arg17)
				{
					handler(arg17, num++, state);
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts9 = ((HashConflictingEntry<K, V>)entry10).Conflicts;
					foreach (ImHashMapEntry<K, V> arg18 in conflicts9)
					{
						handler(arg18, num++, state);
					}
				}
				if (entry8 is ImHashMapEntry<K, V> arg19)
				{
					handler(arg19, num++, state);
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts10 = ((HashConflictingEntry<K, V>)entry8).Conflicts;
					foreach (ImHashMapEntry<K, V> arg20 in conflicts10)
					{
						handler(arg20, num++, state);
					}
				}
				if (entry7 is ImHashMapEntry<K, V> arg21)
				{
					handler(arg21, num++, state);
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts11 = ((HashConflictingEntry<K, V>)entry7).Conflicts;
					foreach (ImHashMapEntry<K, V> arg22 in conflicts11)
					{
						handler(arg22, num++, state);
					}
				}
			}
			else if (map is ImHashMap<K, V>.Leaf5 leaf2)
			{
				if (leaf2.Entry0 is ImHashMapEntry<K, V> arg23)
				{
					handler(arg23, num++, state);
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts12 = ((HashConflictingEntry<K, V>)leaf2.Entry0).Conflicts;
					foreach (ImHashMapEntry<K, V> arg24 in conflicts12)
					{
						handler(arg24, num++, state);
					}
				}
				if (leaf2.Entry1 is ImHashMapEntry<K, V> arg25)
				{
					handler(arg25, num++, state);
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts13 = ((HashConflictingEntry<K, V>)leaf2.Entry1).Conflicts;
					foreach (ImHashMapEntry<K, V> arg26 in conflicts13)
					{
						handler(arg26, num++, state);
					}
				}
				if (leaf2.Entry2 is ImHashMapEntry<K, V> arg27)
				{
					handler(arg27, num++, state);
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts14 = ((HashConflictingEntry<K, V>)leaf2.Entry2).Conflicts;
					foreach (ImHashMapEntry<K, V> arg28 in conflicts14)
					{
						handler(arg28, num++, state);
					}
				}
				if (leaf2.Entry3 is ImHashMapEntry<K, V> arg29)
				{
					handler(arg29, num++, state);
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts15 = ((HashConflictingEntry<K, V>)leaf2.Entry3).Conflicts;
					foreach (ImHashMapEntry<K, V> arg30 in conflicts15)
					{
						handler(arg30, num++, state);
					}
				}
				if (leaf2.Entry4 is ImHashMapEntry<K, V> arg31)
				{
					handler(arg31, num++, state);
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts16 = ((HashConflictingEntry<K, V>)leaf2.Entry4).Conflicts;
					foreach (ImHashMapEntry<K, V> arg32 in conflicts16)
					{
						handler(arg32, num++, state);
					}
				}
			}
			else if (map is ImHashMap<K, V>.Leaf5Plus1 { Plus: var entry12 } leaf5Plus)
			{
				int hash3 = entry12.Hash;
				ImHashMap<K, V>.Leaf5 l4 = leaf5Plus.L;
				ImHashMap<K, V>.Entry entry13 = l4.Entry0;
				ImHashMap<K, V>.Entry entry14 = l4.Entry1;
				ImHashMap<K, V>.Entry entry15 = l4.Entry2;
				ImHashMap<K, V>.Entry entry16 = l4.Entry3;
				ImHashMap<K, V>.Entry entry17 = l4.Entry4;
				ImHashMap<K, V>.Entry entry18 = null;
				if (hash3 < entry17.Hash)
				{
					entry18 = entry17;
					entry17 = entry12;
					entry12 = entry18;
					if (hash3 < entry16.Hash)
					{
						entry18 = entry16;
						entry16 = entry17;
						entry17 = entry18;
						if (hash3 < entry15.Hash)
						{
							entry18 = entry15;
							entry15 = entry16;
							entry16 = entry18;
							if (hash3 < entry14.Hash)
							{
								entry18 = entry14;
								entry14 = entry15;
								entry15 = entry18;
								if (hash3 < entry13.Hash)
								{
									entry18 = entry13;
									entry13 = entry14;
									entry14 = entry18;
								}
							}
						}
					}
				}
				if (entry13 is ImHashMapEntry<K, V> arg33)
				{
					handler(arg33, num++, state);
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts17 = ((HashConflictingEntry<K, V>)entry13).Conflicts;
					foreach (ImHashMapEntry<K, V> arg34 in conflicts17)
					{
						handler(arg34, num++, state);
					}
				}
				if (entry14 is ImHashMapEntry<K, V> arg35)
				{
					handler(arg35, num++, state);
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts18 = ((HashConflictingEntry<K, V>)entry14).Conflicts;
					foreach (ImHashMapEntry<K, V> arg36 in conflicts18)
					{
						handler(arg36, num++, state);
					}
				}
				if (entry15 is ImHashMapEntry<K, V> arg37)
				{
					handler(arg37, num++, state);
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts19 = ((HashConflictingEntry<K, V>)entry15).Conflicts;
					foreach (ImHashMapEntry<K, V> arg38 in conflicts19)
					{
						handler(arg38, num++, state);
					}
				}
				if (entry16 is ImHashMapEntry<K, V> arg39)
				{
					handler(arg39, num++, state);
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts20 = ((HashConflictingEntry<K, V>)entry16).Conflicts;
					foreach (ImHashMapEntry<K, V> arg40 in conflicts20)
					{
						handler(arg40, num++, state);
					}
				}
				if (entry17 is ImHashMapEntry<K, V> arg41)
				{
					handler(arg41, num++, state);
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts21 = ((HashConflictingEntry<K, V>)entry17).Conflicts;
					foreach (ImHashMapEntry<K, V> arg42 in conflicts21)
					{
						handler(arg42, num++, state);
					}
				}
				if (entry12 is ImHashMapEntry<K, V> arg43)
				{
					handler(arg43, num++, state);
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts22 = ((HashConflictingEntry<K, V>)entry12).Conflicts;
					foreach (ImHashMapEntry<K, V> arg44 in conflicts22)
					{
						handler(arg44, num++, state);
					}
				}
			}
			else if (map is ImHashMap<K, V>.Leaf5Plus1Plus1 leaf5Plus1Plus)
			{
				ImHashMap<K, V>.Leaf5 l5 = leaf5Plus1Plus.L.L;
				ImHashMap<K, V>.Entry entry19 = l5.Entry0;
				ImHashMap<K, V>.Entry entry20 = l5.Entry1;
				ImHashMap<K, V>.Entry entry21 = l5.Entry2;
				ImHashMap<K, V>.Entry entry22 = l5.Entry3;
				ImHashMap<K, V>.Entry entry23 = l5.Entry4;
				ImHashMap<K, V>.Entry entry24 = leaf5Plus1Plus.Plus;
				ImHashMap<K, V>.Entry entry25 = leaf5Plus1Plus.L.Plus;
				ImHashMap<K, V>.Entry entry26 = null;
				int hash4 = entry25.Hash;
				if (hash4 < entry23.Hash)
				{
					entry26 = entry23;
					entry23 = entry25;
					entry25 = entry26;
					if (hash4 < entry22.Hash)
					{
						entry26 = entry22;
						entry22 = entry23;
						entry23 = entry26;
						if (hash4 < entry21.Hash)
						{
							entry26 = entry21;
							entry21 = entry22;
							entry22 = entry26;
							if (hash4 < entry20.Hash)
							{
								entry26 = entry20;
								entry20 = entry21;
								entry21 = entry26;
								if (hash4 < entry19.Hash)
								{
									entry26 = entry19;
									entry19 = entry20;
									entry20 = entry26;
								}
							}
						}
					}
				}
				hash4 = entry24.Hash;
				if (hash4 < entry25.Hash)
				{
					entry26 = entry25;
					entry25 = entry24;
					entry24 = entry26;
					if (hash4 < entry23.Hash)
					{
						entry26 = entry23;
						entry23 = entry25;
						entry25 = entry26;
						if (hash4 < entry22.Hash)
						{
							entry26 = entry22;
							entry22 = entry23;
							entry23 = entry26;
							if (hash4 < entry21.Hash)
							{
								entry26 = entry21;
								entry21 = entry22;
								entry22 = entry26;
								if (hash4 < entry20.Hash)
								{
									entry26 = entry20;
									entry20 = entry21;
									entry21 = entry26;
									if (hash4 < entry19.Hash)
									{
										entry26 = entry19;
										entry19 = entry20;
										entry20 = entry26;
									}
								}
							}
						}
					}
				}
				if (entry19 is ImHashMapEntry<K, V> arg45)
				{
					handler(arg45, num++, state);
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts23 = ((HashConflictingEntry<K, V>)entry19).Conflicts;
					foreach (ImHashMapEntry<K, V> arg46 in conflicts23)
					{
						handler(arg46, num++, state);
					}
				}
				if (entry20 is ImHashMapEntry<K, V> arg47)
				{
					handler(arg47, num++, state);
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts24 = ((HashConflictingEntry<K, V>)entry20).Conflicts;
					foreach (ImHashMapEntry<K, V> arg48 in conflicts24)
					{
						handler(arg48, num++, state);
					}
				}
				if (entry21 is ImHashMapEntry<K, V> arg49)
				{
					handler(arg49, num++, state);
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts25 = ((HashConflictingEntry<K, V>)entry21).Conflicts;
					foreach (ImHashMapEntry<K, V> arg50 in conflicts25)
					{
						handler(arg50, num++, state);
					}
				}
				if (entry22 is ImHashMapEntry<K, V> arg51)
				{
					handler(arg51, num++, state);
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts26 = ((HashConflictingEntry<K, V>)entry22).Conflicts;
					foreach (ImHashMapEntry<K, V> arg52 in conflicts26)
					{
						handler(arg52, num++, state);
					}
				}
				if (entry23 is ImHashMapEntry<K, V> arg53)
				{
					handler(arg53, num++, state);
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts27 = ((HashConflictingEntry<K, V>)entry23).Conflicts;
					foreach (ImHashMapEntry<K, V> arg54 in conflicts27)
					{
						handler(arg54, num++, state);
					}
				}
				if (entry25 is ImHashMapEntry<K, V> arg55)
				{
					handler(arg55, num++, state);
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts28 = ((HashConflictingEntry<K, V>)entry25).Conflicts;
					foreach (ImHashMapEntry<K, V> arg56 in conflicts28)
					{
						handler(arg56, num++, state);
					}
				}
				if (entry24 is ImHashMapEntry<K, V> arg57)
				{
					handler(arg57, num++, state);
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts29 = ((HashConflictingEntry<K, V>)entry24).Conflicts;
					foreach (ImHashMapEntry<K, V> arg58 in conflicts29)
					{
						handler(arg58, num++, state);
					}
				}
			}
			if (num2 == 0)
			{
				break;
			}
			object obj = parents.Get(--num2);
			if (obj is ImHashMap<K, V>.Branch2 branch3)
			{
				if (branch3.MidEntry is ImHashMapEntry<K, V> arg59)
				{
					handler(arg59, num++, state);
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts30 = ((HashConflictingEntry<K, V>)branch3.MidEntry).Conflicts;
					foreach (ImHashMapEntry<K, V> arg60 in conflicts30)
					{
						handler(arg60, num++, state);
					}
				}
				map = branch3.Right;
				continue;
			}
			if (obj != _enumerationB3Tombstone)
			{
				ImHashMap<K, V>.Branch3 branch4 = (ImHashMap<K, V>.Branch3)obj;
				if (branch4.Entry0 is ImHashMapEntry<K, V> arg61)
				{
					handler(arg61, num++, state);
				}
				else
				{
					ImHashMapEntry<K, V>[] conflicts31 = ((HashConflictingEntry<K, V>)branch4.Entry0).Conflicts;
					foreach (ImHashMapEntry<K, V> arg62 in conflicts31)
					{
						handler(arg62, num++, state);
					}
				}
				map = branch4.Middle;
				parents.Put(_enumerationB3Tombstone, ++num2);
				num2++;
				continue;
			}
			ImHashMap<K, V>.Branch3 branch5 = (ImHashMap<K, V>.Branch3)parents.Get(--num2);
			if (branch5.Entry1 is ImHashMapEntry<K, V> arg63)
			{
				handler(arg63, num++, state);
			}
			else
			{
				ImHashMapEntry<K, V>[] conflicts32 = ((HashConflictingEntry<K, V>)branch5.Entry1).Conflicts;
				foreach (ImHashMapEntry<K, V> arg64 in conflicts32)
				{
					handler(arg64, num++, state);
				}
			}
			map = branch5.Right;
		}
		return state;
	}

	public static void ForEach<K, V>(this ImHashMap<K, V> map, Action<ImHashMapEntry<K, V>, int> handler, MapParentStack parents = null)
	{
		map.ForEach(handler, delegate(ImHashMapEntry<K, V> e, int i, Action<ImHashMapEntry<K, V>, int> r)
		{
			r(e, i);
		}, parents);
	}

	public static S Fold<K, V, S>(this ImHashMap<K, V> map, S state, Func<ImHashMapEntry<K, V>, int, S, S> handler, MapParentStack parents = null)
	{
		return map.ForEach(St.Rent(state, handler), delegate(ImHashMapEntry<K, V> e, int i, St<S, Func<ImHashMapEntry<K, V>, int, S, S>> s)
		{
			s.a = s.b(e, i, s.a);
		}, parents).ResetButGetA();
	}

	public static S[] ToArray<K, V, S>(this ImHashMap<K, V> map, Func<ImHashMapEntry<K, V>, S> selector)
	{
		if (map != ImHashMap<K, V>.Empty)
		{
			return map.ForEach(St.Rent(new S[map.Count()], selector), delegate(ImHashMapEntry<K, V> e, int i, St<S[], Func<ImHashMapEntry<K, V>, S>> s)
			{
				s.a[i] = s.b(e);
			}).ResetButGetA();
		}
		return ArrayTools.Empty<S>();
	}

	public static ImHashMapEntry<K, V>[] ToArray<K, V>(this ImHashMap<K, V> map)
	{
		if (map != ImHashMap<K, V>.Empty)
		{
			return map.ForEach(new ImHashMapEntry<K, V>[map.Count()], delegate(ImHashMapEntry<K, V> e, int i, ImHashMapEntry<K, V>[] a)
			{
				a[i] = e;
			});
		}
		return ArrayTools.Empty<ImHashMapEntry<K, V>>();
	}

	public static Dictionary<K, V> ToDictionary<K, V>(this ImHashMap<K, V> map)
	{
		if (map != ImHashMap<K, V>.Empty)
		{
			return map.ForEach(new Dictionary<K, V>(), delegate(ImHashMapEntry<K, V> e, int _, Dictionary<K, V> d)
			{
				d.Add(e.Key, e.Value);
			});
		}
		return new Dictionary<K, V>(0);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ImHashMapEntry<K, V> GetEntryOrDefault<K, V>(this ImHashMap<K, V> map, int hash, K key)
	{
		ImHashMap<K, V>.Entry entryOrNull = map.GetEntryOrNull(hash);
		if (entryOrNull is ImHashMapEntry<K, V> { Key: var key2 } imHashMapEntry)
		{
			if (!key2.Equals(key))
			{
				return null;
			}
			return imHashMapEntry;
		}
		if (entryOrNull is HashConflictingEntry<K, V> { Conflicts: var conflicts })
		{
			foreach (ImHashMapEntry<K, V> imHashMapEntry2 in conflicts)
			{
				if (imHashMapEntry2.Key.Equals(key))
				{
					return imHashMapEntry2;
				}
			}
		}
		return null;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ImHashMapEntry<K, V> GetEntryOrDefaultByReferenceEquals<K, V>(this ImHashMap<K, V> map, int hash, K key) where K : class
	{
		ImHashMap<K, V>.Entry entryOrNull = map.GetEntryOrNull(hash);
		if (!(entryOrNull is ImHashMapEntry<K, V> imHashMapEntry))
		{
			return GetEntryOrDefaultFromConflictingEntryByReferenceEquals(entryOrNull, key);
		}
		if (imHashMapEntry.Key != key)
		{
			return null;
		}
		return imHashMapEntry;
	}

	private static ImHashMapEntry<K, V> GetEntryOrDefaultFromConflictingEntryByReferenceEquals<K, V>(ImHashMap<K, V>.Entry e, K key) where K : class
	{
		if (e is HashConflictingEntry<K, V> { Conflicts: var conflicts })
		{
			foreach (ImHashMapEntry<K, V> imHashMapEntry in conflicts)
			{
				if (imHashMapEntry.Key == key)
				{
					return imHashMapEntry;
				}
			}
		}
		return null;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ImHashMapEntry<K, V> GetEntryOrDefault<K, V>(this ImHashMap<K, V> map, K key)
	{
		return map.GetEntryOrDefault(key.GetHashCode(), key);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool Contains<K, V>(this ImHashMap<K, V> map, int hash, K key)
	{
		return map.GetEntryOrDefault(hash, key) != null;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool Contains<K, V>(this ImHashMap<K, V> map, K key)
	{
		return map.GetEntryOrDefault(key.GetHashCode(), key) != null;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ImHashMapEntry<K, V> GetSurePresentEntry<K, V>(this ImHashMap<K, V> map, int hash, K key)
	{
		ImHashMap<K, V>.Entry entryOrNull = map.GetEntryOrNull(hash);
		if (entryOrNull is HashConflictingEntry<K, V> { Conflicts: var conflicts })
		{
			foreach (ImHashMapEntry<K, V> imHashMapEntry in conflicts)
			{
				if (imHashMapEntry.Key.Equals(key))
				{
					return imHashMapEntry;
				}
			}
		}
		return (ImHashMapEntry<K, V>)entryOrNull;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static V GetValueOrDefault<K, V>(this ImHashMap<K, V> map, int hash, K key)
	{
		ImHashMap<K, V>.Entry entryOrNull = map.GetEntryOrNull(hash);
		if (entryOrNull is ImHashMapEntry<K, V> { Key: var key2 } imHashMapEntry)
		{
			if (key2.Equals(key))
			{
				return imHashMapEntry.Value;
			}
		}
		else if (entryOrNull is HashConflictingEntry<K, V> { Conflicts: var conflicts })
		{
			foreach (ImHashMapEntry<K, V> imHashMapEntry2 in conflicts)
			{
				if (imHashMapEntry2.Key.Equals(key))
				{
					return imHashMapEntry2.Value;
				}
			}
		}
		return default(V);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static V GetValueOrDefault<K, V>(this ImHashMap<K, V> map, K key)
	{
		return map.GetValueOrDefault(key.GetHashCode(), key);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static V GetValueOrDefaultByReferenceEquals<K, V>(this ImHashMap<K, V> map, int hash, K key) where K : class
	{
		ImHashMap<K, V>.Entry entryOrNull = map.GetEntryOrNull(hash);
		if (entryOrNull is ImHashMapEntry<K, V> imHashMapEntry)
		{
			if (imHashMapEntry.Key == key)
			{
				return imHashMapEntry.Value;
			}
		}
		else if (entryOrNull is HashConflictingEntry<K, V> { Conflicts: var conflicts })
		{
			foreach (ImHashMapEntry<K, V> imHashMapEntry2 in conflicts)
			{
				if (imHashMapEntry2.Key == key)
				{
					return imHashMapEntry2.Value;
				}
			}
		}
		return default(V);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryFind<K, V>(this ImHashMap<K, V> map, int hash, K key, out V value)
	{
		ImHashMap<K, V>.Entry entryOrNull = map.GetEntryOrNull(hash);
		if (entryOrNull is ImHashMapEntry<K, V> { Key: var key2 } imHashMapEntry)
		{
			if (key2.Equals(key))
			{
				value = imHashMapEntry.Value;
				return true;
			}
		}
		else if (entryOrNull is HashConflictingEntry<K, V> { Conflicts: var conflicts })
		{
			foreach (ImHashMapEntry<K, V> imHashMapEntry2 in conflicts)
			{
				if (imHashMapEntry2.Key.Equals(key))
				{
					value = imHashMapEntry2.Value;
					return true;
				}
			}
		}
		value = default(V);
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryFindByReferenceEquals<K, V>(this ImHashMap<K, V> map, int hash, K key, out V value) where K : class
	{
		ImHashMap<K, V>.Entry entryOrNull = map.GetEntryOrNull(hash);
		if (entryOrNull is ImHashMapEntry<K, V> imHashMapEntry)
		{
			if (imHashMapEntry.Key == key)
			{
				value = imHashMapEntry.Value;
				return true;
			}
		}
		else if (entryOrNull is HashConflictingEntry<K, V> { Conflicts: var conflicts })
		{
			foreach (ImHashMapEntry<K, V> imHashMapEntry2 in conflicts)
			{
				if (imHashMapEntry2.Key == key)
				{
					value = imHashMapEntry2.Value;
					return true;
				}
			}
		}
		value = default(V);
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryFind<K, V>(this ImHashMap<K, V> map, K key, out V value)
	{
		return map.TryFind(key.GetHashCode(), key, out value);
	}

	public static ImHashMap<K, V> AddOrGetEntry<K, V>(this ImHashMap<K, V> map, ImHashMapEntry<K, V> newEntry)
	{
		int hash = newEntry.Hash;
		ImHashMap<K, V> imHashMap = map.AddOrGetEntry(hash, newEntry);
		if (imHashMap is ImHashMap<K, V>.Entry entry && entry != newEntry)
		{
			K val;
			if (entry is ImHashMapEntry<K, V> imHashMapEntry)
			{
				val = imHashMapEntry.Key;
				object obj = newEntry.Key;
				if (!val.Equals(obj))
				{
					return map.ReplaceEntry(hash, entry, new HashConflictingEntry<K, V>(hash, imHashMapEntry, newEntry));
				}
				return entry;
			}
			K key = newEntry.Key;
			ImHashMapEntry<K, V>[] conflicts = ((HashConflictingEntry<K, V>)entry).Conflicts;
			int num;
			for (num = conflicts.Length - 1; num != -1; num--)
			{
				ref K reference = ref key;
				val = default(K);
				if (val == null)
				{
					val = reference;
					reference = ref val;
				}
				object obj2 = conflicts[num].Key;
				if (reference.Equals(obj2))
				{
					break;
				}
			}
			if (num == -1)
			{
				return map.ReplaceEntry(hash, entry, new HashConflictingEntry<K, V>(hash, conflicts.AppendToNonEmpty(newEntry)));
			}
			return conflicts[num];
		}
		return imHashMap;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ImHashMap<K, V> AddOrUpdate<K, V>(this ImHashMap<K, V> map, int hash, K key, V value)
	{
		ImHashMapEntry<K, V> imHashMapEntry = new ImHashMapEntry<K, V>(hash, key, value);
		ImHashMap<K, V> imHashMap = map.AddOrGetEntry(hash, imHashMapEntry);
		if (!(imHashMap is ImHashMap<K, V>.Entry entry))
		{
			return imHashMap;
		}
		if (entry != imHashMapEntry)
		{
			return map.ReplaceEntry(hash, entry, entry.Update(imHashMapEntry));
		}
		return imHashMapEntry;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ImHashMap<K, V> AddOrUpdateEntry<K, V>(this ImHashMap<K, V> map, ImHashMapEntry<K, V> newEntry)
	{
		int hash = newEntry.Hash;
		ImHashMap<K, V> imHashMap = map.AddOrGetEntry(hash, newEntry);
		if (!(imHashMap is ImHashMap<K, V>.Entry entry))
		{
			return imHashMap;
		}
		if (entry != newEntry)
		{
			return map.ReplaceEntry(hash, entry, entry.Update(newEntry));
		}
		return newEntry;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ImHashMap<K, V> AddOrUpdate<K, V>(this ImHashMap<K, V> map, K key, V value)
	{
		return map.AddOrUpdate(key.GetHashCode(), key, value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ImHashMap<K, V> AddOrUpdate<K, V>(this ImHashMap<K, V> map, int hash, K key, V value, Update<K, V> update)
	{
		ImHashMapEntry<K, V> imHashMapEntry = new ImHashMapEntry<K, V>(hash, key, value);
		ImHashMap<K, V> imHashMap = map.AddOrGetEntry(hash, imHashMapEntry);
		if (!(imHashMap is ImHashMap<K, V>.Entry entry))
		{
			return imHashMap;
		}
		if (entry != imHashMapEntry)
		{
			return map.ReplaceEntry(hash, entry, UpdateEntry(entry, imHashMapEntry, update));
		}
		return imHashMapEntry;
	}

	internal static ImHashMap<K, V>.Entry UpdateEntry<K, V>(ImHashMap<K, V>.Entry oldEntry, ImHashMapEntry<K, V> newEntry, Update<K, V> update)
	{
		K key = newEntry.Key;
		K val;
		if (oldEntry is ImHashMapEntry<K, V> imHashMapEntry)
		{
			val = imHashMapEntry.Key;
			object obj = key;
			if (!val.Equals(obj))
			{
				return new HashConflictingEntry<K, V>(oldEntry.Hash, imHashMapEntry, newEntry);
			}
			return new ImHashMapEntry<K, V>(newEntry.Hash, key, update(key, imHashMapEntry.Value, newEntry.Value));
		}
		ImHashMapEntry<K, V>[] conflicts = ((HashConflictingEntry<K, V>)oldEntry).Conflicts;
		int num;
		for (num = conflicts.Length - 1; num != -1; num--)
		{
			ref K reference = ref key;
			val = default(K);
			if (val == null)
			{
				val = reference;
				reference = ref val;
			}
			object obj2 = conflicts[num].Key;
			if (reference.Equals(obj2))
			{
				break;
			}
		}
		return new HashConflictingEntry<K, V>(oldEntry.Hash, conflicts.AppendOrUpdate(newEntry, num));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ImHashMap<K, V> AddOrUpdate<K, V>(this ImHashMap<K, V> map, K key, V value, Update<K, V> update)
	{
		return map.AddOrUpdate(key.GetHashCode(), key, value, update);
	}

	public static ImHashMap<K, V> Update<K, V>(this ImHashMap<K, V> map, int hash, K key, V value)
	{
		ImHashMap<K, V>.Entry entryOrNull = map.GetEntryOrNull(hash);
		if (entryOrNull == null)
		{
			return map;
		}
		K val;
		if (entryOrNull is ImHashMapEntry<K, V> imHashMapEntry)
		{
			val = imHashMapEntry.Key;
			object obj = key;
			if (!val.Equals(obj))
			{
				return map;
			}
			return map.ReplaceEntry(hash, entryOrNull, new ImHashMapEntry<K, V>(hash, key, value));
		}
		ImHashMapEntry<K, V>[] conflicts = ((HashConflictingEntry<K, V>)entryOrNull).Conflicts;
		int num;
		for (num = conflicts.Length - 1; num != -1; num--)
		{
			ref K reference = ref key;
			val = default(K);
			if (val == null)
			{
				val = reference;
				reference = ref val;
			}
			object obj2 = conflicts[num].Key;
			if (reference.Equals(obj2))
			{
				break;
			}
		}
		if (num != -1)
		{
			return map.ReplaceEntry(hash, entryOrNull, new HashConflictingEntry<K, V>(hash, conflicts.UpdateNonEmpty(new ImHashMapEntry<K, V>(hash, key, value), num)));
		}
		return map;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ImHashMap<K, V> Update<K, V>(this ImHashMap<K, V> map, K key, V value)
	{
		return map.Update(key.GetHashCode(), key, value);
	}

	public static ImHashMap<K, V> UpdateToDefault<K, V>(this ImHashMap<K, V> map, int hash, K key)
	{
		ImHashMap<K, V>.Entry entryOrNull = map.GetEntryOrNull(hash);
		if (entryOrNull == null)
		{
			return map;
		}
		K val;
		if (entryOrNull is ImHashMapEntry<K, V> imHashMapEntry)
		{
			val = imHashMapEntry.Key;
			object obj = key;
			if (!val.Equals(obj))
			{
				return map;
			}
			return map.ReplaceEntry(hash, entryOrNull, new ImHashMapEntry<K, V>(hash, key));
		}
		ImHashMapEntry<K, V>[] conflicts = ((HashConflictingEntry<K, V>)entryOrNull).Conflicts;
		int num;
		for (num = conflicts.Length - 1; num != -1; num--)
		{
			ref K reference = ref key;
			val = default(K);
			if (val == null)
			{
				val = reference;
				reference = ref val;
			}
			object obj2 = conflicts[num].Key;
			if (reference.Equals(obj2))
			{
				break;
			}
		}
		if (num != -1)
		{
			return map.ReplaceEntry(hash, entryOrNull, new HashConflictingEntry<K, V>(hash, conflicts.UpdateNonEmpty(new ImHashMapEntry<K, V>(hash, key), num)));
		}
		return map;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ImHashMap<K, V> UpdateToDefault<K, V>(this ImHashMap<K, V> map, K key)
	{
		return map.UpdateToDefault(key.GetHashCode(), key);
	}

	public static ImHashMap<K, V> Update<K, V>(this ImHashMap<K, V> map, int hash, K key, V value, Update<K, V> update)
	{
		ImHashMap<K, V>.Entry entryOrNull = map.GetEntryOrNull(hash);
		if (entryOrNull == null)
		{
			return map;
		}
		K val;
		if (entryOrNull is ImHashMapEntry<K, V> imHashMapEntry)
		{
			val = imHashMapEntry.Key;
			object obj = key;
			if (val.Equals(obj) && (object)imHashMapEntry.Value != (object)(value = update(key, imHashMapEntry.Value, value)))
			{
				return map.ReplaceEntry(hash, entryOrNull, new ImHashMapEntry<K, V>(hash, key, value));
			}
			return map;
		}
		ImHashMapEntry<K, V>[] conflicts = ((HashConflictingEntry<K, V>)entryOrNull).Conflicts;
		int num;
		for (num = conflicts.Length - 1; num != -1; num--)
		{
			ref K reference = ref key;
			val = default(K);
			if (val == null)
			{
				val = reference;
				reference = ref val;
			}
			object obj2 = conflicts[num].Key;
			if (reference.Equals(obj2))
			{
				break;
			}
		}
		if (num == -1 || (object)conflicts[num].Value == (object)(value = update(key, conflicts[num].Value, value)))
		{
			return map;
		}
		return map.ReplaceEntry(hash, entryOrNull, new HashConflictingEntry<K, V>(hash, conflicts.UpdateNonEmpty(new ImHashMapEntry<K, V>(hash, key, value), num)));
	}

	public static ImHashMap<K, V> Update<K, V>(this ImHashMap<K, V> map, K key, V value, Update<K, V> update)
	{
		return map.Update(key.GetHashCode(), key, value, update);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ImHashMap<K, V> AddOrKeepEntry<K, V>(this ImHashMap<K, V> map, ImHashMapEntry<K, V> newEntry)
	{
		int hash = newEntry.Hash;
		ImHashMap<K, V> imHashMap = map.AddOrGetEntry(hash, newEntry);
		if (imHashMap is ImHashMap<K, V>.Entry entry && entry != newEntry)
		{
			ImHashMap<K, V>.Entry entry2 = KeepOrAddEntry(entry, newEntry);
			if (entry2 != entry)
			{
				return map.ReplaceEntry(hash, entry, entry2);
			}
			return map;
		}
		return imHashMap;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ImHashMap<K, V> AddOrKeep<K, V>(this ImHashMap<K, V> map, int hash, K key, V value)
	{
		ImHashMapEntry<K, V> imHashMapEntry = new ImHashMapEntry<K, V>(hash, key, value);
		ImHashMap<K, V> imHashMap = map.AddOrGetEntry(hash, imHashMapEntry);
		if (imHashMap is ImHashMap<K, V>.Entry entry && entry != imHashMapEntry)
		{
			ImHashMap<K, V>.Entry entry2 = KeepOrAddEntry(entry, imHashMapEntry);
			if (entry2 != entry)
			{
				return map.ReplaceEntry(hash, entry, entry2);
			}
			return map;
		}
		return imHashMap;
	}

	private static ImHashMap<K, V>.Entry KeepOrAddEntry<K, V>(ImHashMap<K, V>.Entry oldEntry, ImHashMapEntry<K, V> newEntry)
	{
		K val;
		if (oldEntry is ImHashMapEntry<K, V> imHashMapEntry)
		{
			val = imHashMapEntry.Key;
			object obj = newEntry.Key;
			if (!val.Equals(obj))
			{
				return new HashConflictingEntry<K, V>(oldEntry.Hash, imHashMapEntry, newEntry);
			}
			return oldEntry;
		}
		K key = newEntry.Key;
		ImHashMapEntry<K, V>[] conflicts = ((HashConflictingEntry<K, V>)oldEntry).Conflicts;
		int num;
		for (num = conflicts.Length - 1; num != -1; num--)
		{
			ref K reference = ref key;
			val = default(K);
			if (val == null)
			{
				val = reference;
				reference = ref val;
			}
			object obj2 = conflicts[num].Key;
			if (reference.Equals(obj2))
			{
				break;
			}
		}
		if (num != -1)
		{
			return oldEntry;
		}
		return new HashConflictingEntry<K, V>(oldEntry.Hash, conflicts.AppendToNonEmpty(newEntry));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ImHashMap<K, V> AddOrKeep<K, V>(this ImHashMap<K, V> map, K key, V value)
	{
		return map.AddOrKeep(key.GetHashCode(), key, value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ImHashMap<K, V> Remove<K, V>(this ImHashMap<K, V> map, int hash, K key)
	{
		ImHashMap<K, V>.Entry entryOrNull = map.GetEntryOrNull(hash);
		if (entryOrNull is ImHashMapEntry<K, V>)
		{
			return map.RemoveEntry(entryOrNull);
		}
		if (entryOrNull is HashConflictingEntry<K, V> hc)
		{
			ImHashMap<K, V>.Entry entry = RemoveEntryToReplaceOrDefault(hc, key);
			if (entry != null)
			{
				return map.ReplaceEntry(hash, entryOrNull, entry);
			}
			return map;
		}
		return map;
	}

	private static ImHashMap<K, V>.Entry RemoveEntryToReplaceOrDefault<K, V>(HashConflictingEntry<K, V> hc, K key)
	{
		ImHashMapEntry<K, V>[] conflicts = hc.Conflicts;
		int num = conflicts.Length;
		int num2 = num - 1;
		while (num2 != -1 && !conflicts[num2].Key.Equals(key))
		{
			num2--;
		}
		if (num2 != -1)
		{
			if (num == 2)
			{
				if (num2 != 0)
				{
					return conflicts[0];
				}
				return conflicts[1];
			}
			ImHashMapEntry<K, V>[] array = new ImHashMapEntry<K, V>[--num];
			if (num2 > 0)
			{
				Array.Copy(conflicts, 0, array, 0, num2);
			}
			if (num2 < num)
			{
				Array.Copy(conflicts, num2 + 1, array, num2, num - num2);
			}
			return new HashConflictingEntry<K, V>(hc.Hash, array);
		}
		return null;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ImHashMap<K, V> Remove<K, V>(this ImHashMap<K, V> map, K key)
	{
		if (map != ImHashMap<K, V>.Empty)
		{
			return map.Remove(key.GetHashCode(), key);
		}
		return map;
	}
}
