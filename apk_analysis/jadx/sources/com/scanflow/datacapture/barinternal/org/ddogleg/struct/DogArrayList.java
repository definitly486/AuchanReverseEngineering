package com.scanflow.datacapture.barinternal.org.ddogleg.struct;

import java.io.Serializable;
import java.util.Collection;
import java.util.Iterator;
import java.util.List;
import java.util.ListIterator;

/* JADX INFO: loaded from: classes3.dex */
public class DogArrayList implements List, Serializable {
    DogArray array;

    public DogArrayList(DogArray dogArray) {
        this.array = dogArray;
    }

    @Override // java.util.List, java.util.Collection
    public int size() {
        return this.array.size;
    }

    @Override // java.util.List, java.util.Collection
    public boolean isEmpty() {
        return this.array.size() == 0;
    }

    @Override // java.util.List, java.util.Collection
    public boolean contains(Object obj) {
        return this.array.contains(obj);
    }

    @Override // java.util.List, java.util.Collection, java.lang.Iterable
    public Iterator iterator() {
        return new MyIterator();
    }

    @Override // java.util.List, java.util.Collection
    public Object[] toArray() {
        DogArray dogArray = this.array;
        int i = dogArray.size;
        Object[] objArr = new Object[i];
        System.arraycopy(dogArray.data, 0, objArr, 0, i);
        return objArr;
    }

    @Override // java.util.List, java.util.Collection
    public Object[] toArray(Object[] objArr) {
        DogArray dogArray = this.array;
        System.arraycopy(dogArray.data, 0, objArr, 0, dogArray.size);
        return objArr;
    }

    @Override // java.util.List, java.util.Collection
    public boolean add(Object obj) {
        throw new RuntimeException("Add is not supported by FastQueue. You need FastArray instead");
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
        throw new RuntimeException("Add is not supported by FastQueue. You need FastArray instead");
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
        this.array.reset();
    }

    @Override // java.util.List
    public Object get(int i) {
        return this.array.data[i];
    }

    @Override // java.util.List
    public Object set(int i, Object obj) {
        throw new RuntimeException("Set is not supported by FastQueue. You need FastArray instead");
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
        return this.array.indexOf(obj);
    }

    @Override // java.util.List
    public int lastIndexOf(Object obj) {
        for (int i = this.array.size - 1; i >= 0; i--) {
            if (this.array.data[i].equals(obj)) {
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
            return this.index < DogArrayList.this.array.size;
        }

        @Override // java.util.ListIterator, java.util.Iterator
        public Object next() {
            Object[] objArr = DogArrayList.this.array.data;
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
            Object[] objArr = DogArrayList.this.array.data;
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
            DogArrayList.this.array.data[this.index - 1] = obj;
        }

        @Override // java.util.ListIterator
        public void add(Object obj) {
            throw new RuntimeException("Add is not supported by FastQueue. Use FastArray instead");
        }
    }
}
