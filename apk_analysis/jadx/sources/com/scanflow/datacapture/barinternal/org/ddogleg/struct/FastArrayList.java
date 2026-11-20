package com.scanflow.datacapture.barinternal.org.ddogleg.struct;

import java.io.Serializable;
import java.util.Collection;
import java.util.Iterator;
import java.util.List;
import java.util.ListIterator;

/* JADX INFO: loaded from: classes3.dex */
public class FastArrayList implements List, Serializable {
    FastArray queue;

    public FastArrayList(FastArray fastArray) {
        this.queue = fastArray;
    }

    @Override // java.util.List, java.util.Collection
    public int size() {
        return this.queue.size;
    }

    @Override // java.util.List, java.util.Collection
    public boolean isEmpty() {
        return this.queue.size() == 0;
    }

    @Override // java.util.List, java.util.Collection
    public boolean contains(Object obj) {
        return this.queue.contains(obj);
    }

    @Override // java.util.List, java.util.Collection, java.lang.Iterable
    public Iterator iterator() {
        return new MyIterator();
    }

    @Override // java.util.List, java.util.Collection
    public Object[] toArray() {
        FastArray fastArray = this.queue;
        int i = fastArray.size;
        Object[] objArr = new Object[i];
        System.arraycopy(fastArray.data, 0, objArr, 0, i);
        return objArr;
    }

    @Override // java.util.List, java.util.Collection
    public Object[] toArray(Object[] objArr) {
        FastArray fastArray = this.queue;
        System.arraycopy(fastArray.data, 0, objArr, 0, fastArray.size);
        return objArr;
    }

    @Override // java.util.List, java.util.Collection
    public boolean add(Object obj) {
        this.queue.add(obj);
        return true;
    }

    @Override // java.util.List, java.util.Collection
    public boolean remove(Object obj) {
        throw new RuntimeException("Not all list operations are supposed.");
    }

    @Override // java.util.List, java.util.Collection
    public boolean containsAll(Collection collection) {
        Iterator it = collection.iterator();
        while (it.hasNext()) {
            if (!contains(it.next())) {
                return false;
            }
        }
        return true;
    }

    @Override // java.util.List, java.util.Collection
    public boolean addAll(Collection collection) {
        Iterator it = collection.iterator();
        boolean zHasNext = it.hasNext();
        while (it.hasNext()) {
            this.queue.add(it.next());
        }
        return zHasNext;
    }

    @Override // java.util.List
    public boolean addAll(int i, Collection collection) {
        throw new RuntimeException("Not all list operations are supposed.");
    }

    @Override // java.util.List, java.util.Collection
    public boolean removeAll(Collection collection) {
        throw new RuntimeException("Not all list operations are supposed.");
    }

    @Override // java.util.List, java.util.Collection
    public boolean retainAll(Collection collection) {
        throw new RuntimeException("Not all list operations are supposed.");
    }

    @Override // java.util.List, java.util.Collection
    public void clear() {
        this.queue.reset();
    }

    @Override // java.util.List
    public Object get(int i) {
        return this.queue.data[i];
    }

    @Override // java.util.List
    public Object set(int i, Object obj) {
        this.queue.data[i] = obj;
        return obj;
    }

    @Override // java.util.List
    public void add(int i, Object obj) {
        throw new RuntimeException("Not all list operations are supposed.");
    }

    @Override // java.util.List
    public Object remove(int i) {
        throw new RuntimeException("Not all list operations are supposed.");
    }

    @Override // java.util.List
    public int indexOf(Object obj) {
        return this.queue.indexOf(obj);
    }

    @Override // java.util.List
    public int lastIndexOf(Object obj) {
        for (int i = this.queue.size - 1; i >= 0; i--) {
            if (this.queue.data[i].equals(obj)) {
                return i;
            }
        }
        return -1;
    }

    @Override // java.util.List
    public ListIterator listIterator() {
        return new MyIterator();
    }

    @Override // java.util.List
    public ListIterator listIterator(int i) {
        throw new RuntimeException("Not supported");
    }

    @Override // java.util.List
    public List subList(int i, int i2) {
        throw new RuntimeException("Not supported");
    }

    public class MyIterator implements ListIterator {
        int index = 0;

        public MyIterator() {
        }

        @Override // java.util.ListIterator, java.util.Iterator
        public boolean hasNext() {
            return this.index < FastArrayList.this.queue.size;
        }

        @Override // java.util.ListIterator, java.util.Iterator
        public Object next() {
            Object[] objArr = FastArrayList.this.queue.data;
            int i = this.index;
            this.index = i + 1;
            return objArr[i];
        }

        @Override // java.util.ListIterator
        public boolean hasPrevious() {
            return this.index > 0;
        }

        @Override // java.util.ListIterator
        public Object previous() {
            Object[] objArr = FastArrayList.this.queue.data;
            int i = this.index - 1;
            this.index = i;
            return objArr[i];
        }

        @Override // java.util.ListIterator
        public int nextIndex() {
            return this.index;
        }

        @Override // java.util.ListIterator
        public int previousIndex() {
            return this.index - 1;
        }

        @Override // java.util.ListIterator, java.util.Iterator
        public void remove() {
            throw new RuntimeException("Not all list operations are supposed.");
        }

        @Override // java.util.ListIterator
        public void set(Object obj) {
            FastArrayList.this.queue.data[this.index - 1] = obj;
        }

        @Override // java.util.ListIterator
        public void add(Object obj) {
            FastArrayList.this.queue.add(obj);
        }
    }
}
