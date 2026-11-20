package androidx.collection;

import androidx.collection.internal.RuntimeHelpersKt;
import com.scanflow.datacapture.barinternal.kotlin.collections.ArraysKt;
import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import com.scanflow.datacapture.barinternal.kotlin.jvm.internal.markers.KMutableList;
import com.scanflow.datacapture.barinternal.kotlin.ranges.IntRange;
import com.scanflow.datacapture.barinternal.kotlin.ranges.RangesKt;
import com.scanflow.datacapture.barinternal.kotlin.sequences.Sequence;
import com.scanflow.datacapture.barinternal.kotlin.sequences.SequencesKt;
import java.util.Arrays;
import java.util.Collection;
import java.util.Iterator;
import java.util.List;
import java.util.ListIterator;
import kotlin.jvm.functions.Function1;
import kotlin.jvm.internal.CollectionToArray;
import kotlin.jvm.internal.DefaultConstructorMarker;
import kotlin.jvm.internal.Intrinsics;
import kotlin.jvm.internal.markers.KMappedMarker;

/* JADX INFO: compiled from: ObjectList.kt */
/* JADX INFO: loaded from: classes.dex */
public final class MutableObjectList<E> extends ObjectList<E> {
    private ObjectListMutableList list;

    public MutableObjectList() {
        this(0, 1, null);
    }

    /* JADX WARN: Multi-variable type inference failed */
    public final void minusAssign(ScatterSet<E> elements) {
        Intrinsics.checkNotNullParameter(elements, "elements");
        Object[] objArr = elements.elements;
        long[] jArr = elements.metadata;
        int length = jArr.length - 2;
        if (length < 0) {
            return;
        }
        int i = 0;
        while (true) {
            long j = jArr[i];
            if ((((~j) << 7) & j & (-9187201950435737472L)) != -9187201950435737472L) {
                int i2 = 8 - ((~(i - length)) >>> 31);
                for (int i3 = 0; i3 < i2; i3++) {
                    if ((255 & j) < 128) {
                        remove(objArr[(i << 3) + i3]);
                    }
                    j >>= 8;
                }
                if (i2 != 8) {
                    return;
                }
            }
            if (i == length) {
                return;
            } else {
                i++;
            }
        }
    }

    /* JADX WARN: Multi-variable type inference failed */
    public final void minusAssign(ObjectList<E> elements) {
        Intrinsics.checkNotNullParameter(elements, "elements");
        Object[] objArr = elements.content;
        int i = elements._size;
        for (int i2 = 0; i2 < i; i2++) {
            remove(objArr[i2]);
        }
    }

    public MutableObjectList(int i) {
        super(i, null);
    }

    public /* synthetic */ MutableObjectList(int i, int i2, DefaultConstructorMarker defaultConstructorMarker) {
        this((i2 & 1) != 0 ? 16 : i);
    }

    public final int getCapacity() {
        return this.content.length;
    }

    public final boolean add(E e) {
        int i = this._size + 1;
        Object[] objArr = this.content;
        if (objArr.length < i) {
            resizeStorage(i, objArr);
        }
        Object[] objArr2 = this.content;
        int i2 = this._size;
        objArr2[i2] = e;
        this._size = i2 + 1;
        return true;
    }

    public final void add(int i, E e) {
        if (i < 0 || i > this._size) {
            throwIndexOutOfBoundsInclusiveException(i);
        }
        int i2 = this._size + 1;
        Object[] objArr = this.content;
        if (objArr.length < i2) {
            resizeStorage(i2, objArr);
        }
        Object[] objArr2 = this.content;
        int i3 = this._size;
        if (i != i3) {
            ArraysKt.copyInto(objArr2, objArr2, i + 1, i, i3);
        }
        objArr2[i] = e;
        this._size++;
    }

    public final boolean addAll(int i, E[] elements) {
        Intrinsics.checkNotNullParameter(elements, "elements");
        if (i < 0 || i > this._size) {
            throwIndexOutOfBoundsInclusiveException(i);
        }
        if (elements.length == 0) {
            return false;
        }
        int length = this._size + elements.length;
        Object[] objArr = this.content;
        if (objArr.length < length) {
            resizeStorage(length, objArr);
        }
        Object[] objArr2 = this.content;
        int i2 = this._size;
        if (i != i2) {
            ArraysKt.copyInto(objArr2, objArr2, elements.length + i, i, i2);
        }
        ArraysKt.copyInto$default(elements, objArr2, i, 0, 0, 12, (Object) null);
        this._size += elements.length;
        return true;
    }

    public final boolean addAll(int i, Collection<? extends E> elements) {
        Intrinsics.checkNotNullParameter(elements, "elements");
        if (i < 0 || i > this._size) {
            throwIndexOutOfBoundsInclusiveException(i);
        }
        int i2 = 0;
        if (elements.isEmpty()) {
            return false;
        }
        int size = this._size + elements.size();
        Object[] objArr = this.content;
        if (objArr.length < size) {
            resizeStorage(size, objArr);
        }
        Object[] objArr2 = this.content;
        if (i != this._size) {
            ArraysKt.copyInto(objArr2, objArr2, elements.size() + i, i, this._size);
        }
        for (Object obj : elements) {
            int i3 = i2 + 1;
            if (i2 < 0) {
                CollectionsKt.throwIndexOverflow();
            }
            objArr2[i2 + i] = obj;
            i2 = i3;
        }
        this._size += elements.size();
        return true;
    }

    public final boolean addAll(int i, ObjectList<E> elements) {
        Intrinsics.checkNotNullParameter(elements, "elements");
        if (i < 0 || i > this._size) {
            throwIndexOutOfBoundsInclusiveException(i);
        }
        if (elements.isEmpty()) {
            return false;
        }
        int i2 = this._size + elements._size;
        Object[] objArr = this.content;
        if (objArr.length < i2) {
            resizeStorage(i2, objArr);
        }
        Object[] objArr2 = this.content;
        int i3 = this._size;
        if (i != i3) {
            ArraysKt.copyInto(objArr2, objArr2, elements._size + i, i, i3);
        }
        ArraysKt.copyInto(elements.content, objArr2, i, 0, elements._size);
        this._size += elements._size;
        return true;
    }

    private final void throwIndexOutOfBoundsInclusiveException(int i) {
        RuntimeHelpersKt.throwIndexOutOfBoundsException("Index " + i + " must be in 0.." + this._size);
    }

    public final boolean addAll(ObjectList<E> elements) {
        Intrinsics.checkNotNullParameter(elements, "elements");
        int i = this._size;
        plusAssign((ObjectList) elements);
        return i != this._size;
    }

    public final boolean addAll(ScatterSet<E> elements) {
        Intrinsics.checkNotNullParameter(elements, "elements");
        int i = this._size;
        plusAssign((ScatterSet) elements);
        return i != this._size;
    }

    public final boolean addAll(E[] elements) {
        Intrinsics.checkNotNullParameter(elements, "elements");
        int i = this._size;
        plusAssign((Object[]) elements);
        return i != this._size;
    }

    public final boolean addAll(List<? extends E> elements) {
        Intrinsics.checkNotNullParameter(elements, "elements");
        int i = this._size;
        plusAssign((List) elements);
        return i != this._size;
    }

    public final boolean addAll(Iterable<? extends E> elements) {
        Intrinsics.checkNotNullParameter(elements, "elements");
        int i = this._size;
        plusAssign((Iterable) elements);
        return i != this._size;
    }

    public final boolean addAll(Sequence elements) {
        Intrinsics.checkNotNullParameter(elements, "elements");
        int i = this._size;
        plusAssign(elements);
        return i != this._size;
    }

    public final void plusAssign(ObjectList<E> elements) {
        Intrinsics.checkNotNullParameter(elements, "elements");
        if (elements.isEmpty()) {
            return;
        }
        int i = this._size + elements._size;
        Object[] objArr = this.content;
        if (objArr.length < i) {
            resizeStorage(i, objArr);
        }
        ArraysKt.copyInto(elements.content, this.content, this._size, 0, elements._size);
        this._size += elements._size;
    }

    /* JADX WARN: Multi-variable type inference failed */
    public final void plusAssign(ScatterSet<E> elements) {
        Intrinsics.checkNotNullParameter(elements, "elements");
        if (elements.isEmpty()) {
            return;
        }
        int size = this._size + elements.getSize();
        Object[] objArr = this.content;
        if (objArr.length < size) {
            resizeStorage(size, objArr);
        }
        Object[] objArr2 = elements.elements;
        long[] jArr = elements.metadata;
        int length = jArr.length - 2;
        if (length < 0) {
            return;
        }
        int i = 0;
        while (true) {
            long j = jArr[i];
            if ((((~j) << 7) & j & (-9187201950435737472L)) != -9187201950435737472L) {
                int i2 = 8 - ((~(i - length)) >>> 31);
                for (int i3 = 0; i3 < i2; i3++) {
                    if ((255 & j) < 128) {
                        add(objArr2[(i << 3) + i3]);
                    }
                    j >>= 8;
                }
                if (i2 != 8) {
                    return;
                }
            }
            if (i == length) {
                return;
            } else {
                i++;
            }
        }
    }

    public final void plusAssign(E[] elements) {
        Intrinsics.checkNotNullParameter(elements, "elements");
        if (elements.length == 0) {
            return;
        }
        int length = this._size + elements.length;
        Object[] objArr = this.content;
        if (objArr.length < length) {
            resizeStorage(length, objArr);
        }
        ArraysKt.copyInto$default(elements, this.content, this._size, 0, 0, 12, (Object) null);
        this._size += elements.length;
    }

    public final void plusAssign(List<? extends E> elements) {
        Intrinsics.checkNotNullParameter(elements, "elements");
        if (elements.isEmpty()) {
            return;
        }
        int i = this._size;
        int size = elements.size() + i;
        Object[] objArr = this.content;
        if (objArr.length < size) {
            resizeStorage(size, objArr);
        }
        Object[] objArr2 = this.content;
        int size2 = elements.size();
        for (int i2 = 0; i2 < size2; i2++) {
            objArr2[i2 + i] = elements.get(i2);
        }
        this._size += elements.size();
    }

    public final void clear() {
        ArraysKt.fill(this.content, (Object) null, 0, this._size);
        this._size = 0;
    }

    public final void trim(int i) {
        int iMax = Math.max(i, this._size);
        Object[] objArr = this.content;
        if (objArr.length > iMax) {
            Object[] objArrCopyOf = Arrays.copyOf(objArr, iMax);
            Intrinsics.checkNotNullExpressionValue(objArrCopyOf, "copyOf(...)");
            this.content = objArrCopyOf;
        }
    }

    public final void ensureCapacity(int i) {
        Object[] objArr = this.content;
        if (objArr.length < i) {
            resizeStorage(i, objArr);
        }
    }

    public final void resizeStorage(int i, Object[] oldContent) {
        Intrinsics.checkNotNullParameter(oldContent, "oldContent");
        int length = oldContent.length;
        this.content = ArraysKt.copyInto(oldContent, new Object[Math.max(i, (length * 3) / 2)], 0, 0, length);
    }

    public final void plusAssign(E e) {
        add(e);
    }

    public final void minusAssign(E e) {
        remove(e);
    }

    public final boolean remove(E e) {
        int iIndexOf = indexOf(e);
        if (iIndexOf < 0) {
            return false;
        }
        removeAt(iIndexOf);
        return true;
    }

    public final void removeIf(Function1<? super E, Boolean> predicate) {
        Intrinsics.checkNotNullParameter(predicate, "predicate");
        int i = this._size;
        Object[] objArr = this.content;
        int i2 = 0;
        IntRange intRangeUntil = RangesKt.until(0, i);
        int first = intRangeUntil.getFirst();
        int last = intRangeUntil.getLast();
        if (first <= last) {
            while (true) {
                objArr[first - i2] = objArr[first];
                if (predicate.invoke(objArr[first]).booleanValue()) {
                    i2++;
                }
                if (first == last) {
                    break;
                } else {
                    first++;
                }
            }
        }
        ArraysKt.fill(objArr, (Object) null, i - i2, i);
        this._size -= i2;
    }

    public final boolean removeAll(E[] elements) {
        Intrinsics.checkNotNullParameter(elements, "elements");
        int i = this._size;
        for (E e : elements) {
            remove(e);
        }
        return i != this._size;
    }

    public final boolean removeAll(ObjectList<E> elements) {
        Intrinsics.checkNotNullParameter(elements, "elements");
        int i = this._size;
        minusAssign((ObjectList) elements);
        return i != this._size;
    }

    public final boolean removeAll(ScatterSet<E> elements) {
        Intrinsics.checkNotNullParameter(elements, "elements");
        int i = this._size;
        minusAssign((ScatterSet) elements);
        return i != this._size;
    }

    public final boolean removeAll(List<? extends E> elements) {
        Intrinsics.checkNotNullParameter(elements, "elements");
        int i = this._size;
        minusAssign((List) elements);
        return i != this._size;
    }

    public final boolean removeAll(Iterable<? extends E> elements) {
        Intrinsics.checkNotNullParameter(elements, "elements");
        int i = this._size;
        minusAssign((Iterable) elements);
        return i != this._size;
    }

    public final boolean removeAll(Sequence elements) {
        Intrinsics.checkNotNullParameter(elements, "elements");
        int i = this._size;
        minusAssign(elements);
        return i != this._size;
    }

    public final void minusAssign(List<? extends E> elements) {
        Intrinsics.checkNotNullParameter(elements, "elements");
        int size = elements.size();
        for (int i = 0; i < size; i++) {
            remove(elements.get(i));
        }
    }

    public final E removeAt(int i) {
        if (i < 0 || i >= this._size) {
            throwIndexOutOfBoundsExclusiveException$collection(i);
        }
        Object[] objArr = this.content;
        E e = (E) objArr[i];
        int i2 = this._size;
        if (i != i2 - 1) {
            ArraysKt.copyInto(objArr, objArr, i, i + 1, i2);
        }
        int i3 = this._size - 1;
        this._size = i3;
        objArr[i3] = null;
        return e;
    }

    public final void removeRange(int i, int i2) {
        int i3;
        if (i < 0 || i > (i3 = this._size) || i2 < 0 || i2 > i3) {
            RuntimeHelpersKt.throwIndexOutOfBoundsException("Start (" + i + ") and end (" + i2 + ") must be in 0.." + this._size);
        }
        if (i2 < i) {
            RuntimeHelpersKt.throwIllegalArgumentException("Start (" + i + ") is more than end (" + i2 + ')');
        }
        if (i2 != i) {
            int i4 = this._size;
            if (i2 < i4) {
                Object[] objArr = this.content;
                ArraysKt.copyInto(objArr, objArr, i, i2, i4);
            }
            int i5 = this._size;
            int i6 = i5 - (i2 - i);
            ArraysKt.fill(this.content, (Object) null, i6, i5);
            this._size = i6;
        }
    }

    public final boolean retainAll(E[] elements) {
        Intrinsics.checkNotNullParameter(elements, "elements");
        int i = this._size;
        Object[] objArr = this.content;
        for (int i2 = i - 1; -1 < i2; i2--) {
            if (ArraysKt.indexOf(elements, objArr[i2]) < 0) {
                removeAt(i2);
            }
        }
        return i != this._size;
    }

    /* JADX WARN: Multi-variable type inference failed */
    public final boolean retainAll(ObjectList<E> elements) {
        Intrinsics.checkNotNullParameter(elements, "elements");
        int i = this._size;
        Object[] objArr = this.content;
        for (int i2 = i - 1; -1 < i2; i2--) {
            if (!elements.contains(objArr[i2])) {
                removeAt(i2);
            }
        }
        return i != this._size;
    }

    public final boolean retainAll(Collection<? extends E> elements) {
        Intrinsics.checkNotNullParameter(elements, "elements");
        int i = this._size;
        Object[] objArr = this.content;
        for (int i2 = i - 1; -1 < i2; i2--) {
            if (!elements.contains(objArr[i2])) {
                removeAt(i2);
            }
        }
        return i != this._size;
    }

    public final boolean retainAll(Iterable<? extends E> elements) {
        Intrinsics.checkNotNullParameter(elements, "elements");
        int i = this._size;
        Object[] objArr = this.content;
        for (int i2 = i - 1; -1 < i2; i2--) {
            if (!CollectionsKt.contains(elements, objArr[i2])) {
                removeAt(i2);
            }
        }
        return i != this._size;
    }

    public final boolean retainAll(Sequence elements) {
        Intrinsics.checkNotNullParameter(elements, "elements");
        int i = this._size;
        Object[] objArr = this.content;
        for (int i2 = i - 1; -1 < i2; i2--) {
            if (!SequencesKt.contains(elements, objArr[i2])) {
                removeAt(i2);
            }
        }
        return i != this._size;
    }

    public final E set(int i, E e) {
        if (i < 0 || i >= this._size) {
            throwIndexOutOfBoundsExclusiveException$collection(i);
        }
        Object[] objArr = this.content;
        E e2 = (E) objArr[i];
        objArr[i] = e;
        return e2;
    }

    @Override // androidx.collection.ObjectList
    public List<E> asList() {
        return asMutableList();
    }

    public final List<E> asMutableList() {
        ObjectListMutableList objectListMutableList = this.list;
        if (objectListMutableList != null) {
            return objectListMutableList;
        }
        ObjectListMutableList objectListMutableList2 = new ObjectListMutableList(this);
        this.list = objectListMutableList2;
        return objectListMutableList2;
    }

    /* JADX INFO: compiled from: ObjectList.kt */
    private static final class MutableObjectListIterator implements ListIterator, KMappedMarker {
        private final List list;
        private int prevIndex;

        public MutableObjectListIterator(List list, int i) {
            Intrinsics.checkNotNullParameter(list, "list");
            this.list = list;
            this.prevIndex = i - 1;
        }

        @Override // java.util.ListIterator, java.util.Iterator
        public boolean hasNext() {
            return this.prevIndex < this.list.size() - 1;
        }

        @Override // java.util.ListIterator, java.util.Iterator
        public Object next() {
            List list = this.list;
            int i = this.prevIndex + 1;
            this.prevIndex = i;
            return list.get(i);
        }

        @Override // java.util.ListIterator, java.util.Iterator
        public void remove() {
            this.list.remove(this.prevIndex);
            this.prevIndex--;
        }

        @Override // java.util.ListIterator
        public boolean hasPrevious() {
            return this.prevIndex >= 0;
        }

        @Override // java.util.ListIterator
        public int nextIndex() {
            return this.prevIndex + 1;
        }

        @Override // java.util.ListIterator
        public Object previous() {
            List list = this.list;
            int i = this.prevIndex;
            this.prevIndex = i - 1;
            return list.get(i);
        }

        @Override // java.util.ListIterator
        public int previousIndex() {
            return this.prevIndex;
        }

        @Override // java.util.ListIterator
        public void add(Object obj) {
            List list = this.list;
            int i = this.prevIndex + 1;
            this.prevIndex = i;
            list.add(i, obj);
        }

        @Override // java.util.ListIterator
        public void set(Object obj) {
            this.list.set(this.prevIndex, obj);
        }
    }

    /* JADX INFO: compiled from: ObjectList.kt */
    private static final class ObjectListMutableList implements List, KMutableList {
        private final MutableObjectList objectList;

        @Override // java.util.List, java.util.Collection
        public Object[] toArray() {
            return CollectionToArray.toArray(this);
        }

        @Override // java.util.List, java.util.Collection
        public Object[] toArray(Object[] array) {
            Intrinsics.checkNotNullParameter(array, "array");
            return CollectionToArray.toArray(this, array);
        }

        public ObjectListMutableList(MutableObjectList objectList) {
            Intrinsics.checkNotNullParameter(objectList, "objectList");
            this.objectList = objectList;
        }

        @Override // java.util.List
        public final /* bridge */ Object remove(int i) {
            return removeAt(i);
        }

        @Override // java.util.List, java.util.Collection
        public final /* bridge */ int size() {
            return getSize();
        }

        public int getSize() {
            return this.objectList.getSize();
        }

        @Override // java.util.List, java.util.Collection
        public boolean contains(Object obj) {
            return this.objectList.contains(obj);
        }

        @Override // java.util.List, java.util.Collection
        public boolean containsAll(Collection elements) {
            Intrinsics.checkNotNullParameter(elements, "elements");
            return this.objectList.containsAll(elements);
        }

        @Override // java.util.List
        public Object get(int i) {
            ObjectListKt.checkIndex(this, i);
            return this.objectList.get(i);
        }

        @Override // java.util.List
        public int indexOf(Object obj) {
            return this.objectList.indexOf(obj);
        }

        @Override // java.util.List, java.util.Collection
        public boolean isEmpty() {
            return this.objectList.isEmpty();
        }

        @Override // java.util.List, java.util.Collection, java.lang.Iterable
        public Iterator iterator() {
            return new MutableObjectListIterator(this, 0);
        }

        @Override // java.util.List
        public int lastIndexOf(Object obj) {
            return this.objectList.lastIndexOf(obj);
        }

        @Override // java.util.List, java.util.Collection
        public boolean add(Object obj) {
            return this.objectList.add(obj);
        }

        @Override // java.util.List
        public void add(int i, Object obj) {
            this.objectList.add(i, obj);
        }

        @Override // java.util.List
        public boolean addAll(int i, Collection elements) {
            Intrinsics.checkNotNullParameter(elements, "elements");
            return this.objectList.addAll(i, elements);
        }

        @Override // java.util.List, java.util.Collection
        public boolean addAll(Collection elements) {
            Intrinsics.checkNotNullParameter(elements, "elements");
            return this.objectList.addAll(elements);
        }

        @Override // java.util.List, java.util.Collection
        public void clear() {
            this.objectList.clear();
        }

        @Override // java.util.List
        public ListIterator listIterator() {
            return new MutableObjectListIterator(this, 0);
        }

        @Override // java.util.List
        public ListIterator listIterator(int i) {
            return new MutableObjectListIterator(this, i);
        }

        @Override // java.util.List, java.util.Collection
        public boolean remove(Object obj) {
            return this.objectList.remove(obj);
        }

        @Override // java.util.List, java.util.Collection
        public boolean removeAll(Collection elements) {
            Intrinsics.checkNotNullParameter(elements, "elements");
            return this.objectList.removeAll(elements);
        }

        public Object removeAt(int i) {
            ObjectListKt.checkIndex(this, i);
            return this.objectList.removeAt(i);
        }

        @Override // java.util.List, java.util.Collection
        public boolean retainAll(Collection elements) {
            Intrinsics.checkNotNullParameter(elements, "elements");
            return this.objectList.retainAll(elements);
        }

        @Override // java.util.List
        public Object set(int i, Object obj) {
            ObjectListKt.checkIndex(this, i);
            return this.objectList.set(i, obj);
        }

        @Override // java.util.List
        public List subList(int i, int i2) {
            ObjectListKt.checkSubIndex(this, i, i2);
            return new SubList(this, i, i2);
        }
    }

    /* JADX WARN: Multi-variable type inference failed */
    public final void minusAssign(Sequence elements) {
        Intrinsics.checkNotNullParameter(elements, "elements");
        Iterator it = elements.iterator();
        while (it.hasNext()) {
            remove(it.next());
        }
    }

    /* JADX WARN: Multi-variable type inference failed */
    public final void plusAssign(Sequence elements) {
        Intrinsics.checkNotNullParameter(elements, "elements");
        Iterator it = elements.iterator();
        while (it.hasNext()) {
            add(it.next());
        }
    }

    /* JADX INFO: compiled from: ObjectList.kt */
    private static final class SubList implements List, KMutableList {
        private int end;
        private final List list;
        private final int start;

        @Override // java.util.List, java.util.Collection
        public Object[] toArray() {
            return CollectionToArray.toArray(this);
        }

        @Override // java.util.List, java.util.Collection
        public Object[] toArray(Object[] array) {
            Intrinsics.checkNotNullParameter(array, "array");
            return CollectionToArray.toArray(this, array);
        }

        public SubList(List list, int i, int i2) {
            Intrinsics.checkNotNullParameter(list, "list");
            this.list = list;
            this.start = i;
            this.end = i2;
        }

        @Override // java.util.List
        public final /* bridge */ Object remove(int i) {
            return removeAt(i);
        }

        @Override // java.util.List, java.util.Collection
        public final /* bridge */ int size() {
            return getSize();
        }

        public int getSize() {
            return this.end - this.start;
        }

        @Override // java.util.List, java.util.Collection
        public boolean contains(Object obj) {
            int i = this.end;
            for (int i2 = this.start; i2 < i; i2++) {
                if (Intrinsics.areEqual(this.list.get(i2), obj)) {
                    return true;
                }
            }
            return false;
        }

        @Override // java.util.List, java.util.Collection
        public boolean containsAll(Collection elements) {
            Intrinsics.checkNotNullParameter(elements, "elements");
            Iterator it = elements.iterator();
            while (it.hasNext()) {
                if (!contains(it.next())) {
                    return false;
                }
            }
            return true;
        }

        @Override // java.util.List
        public Object get(int i) {
            ObjectListKt.checkIndex(this, i);
            return this.list.get(i + this.start);
        }

        @Override // java.util.List
        public int indexOf(Object obj) {
            int i = this.end;
            for (int i2 = this.start; i2 < i; i2++) {
                if (Intrinsics.areEqual(this.list.get(i2), obj)) {
                    return i2 - this.start;
                }
            }
            return -1;
        }

        @Override // java.util.List, java.util.Collection
        public boolean isEmpty() {
            return this.end == this.start;
        }

        @Override // java.util.List, java.util.Collection, java.lang.Iterable
        public Iterator iterator() {
            return new MutableObjectListIterator(this, 0);
        }

        @Override // java.util.List
        public int lastIndexOf(Object obj) {
            int i = this.end - 1;
            int i2 = this.start;
            if (i2 > i) {
                return -1;
            }
            while (!Intrinsics.areEqual(this.list.get(i), obj)) {
                if (i == i2) {
                    return -1;
                }
                i--;
            }
            return i - this.start;
        }

        @Override // java.util.List, java.util.Collection
        public boolean add(Object obj) {
            List list = this.list;
            int i = this.end;
            this.end = i + 1;
            list.add(i, obj);
            return true;
        }

        @Override // java.util.List
        public void add(int i, Object obj) {
            this.list.add(i + this.start, obj);
            this.end++;
        }

        @Override // java.util.List
        public boolean addAll(int i, Collection elements) {
            Intrinsics.checkNotNullParameter(elements, "elements");
            this.list.addAll(i + this.start, elements);
            this.end += elements.size();
            return elements.size() > 0;
        }

        @Override // java.util.List, java.util.Collection
        public boolean addAll(Collection elements) {
            Intrinsics.checkNotNullParameter(elements, "elements");
            this.list.addAll(this.end, elements);
            this.end += elements.size();
            return elements.size() > 0;
        }

        @Override // java.util.List, java.util.Collection
        public void clear() {
            int i = this.end - 1;
            int i2 = this.start;
            if (i2 <= i) {
                while (true) {
                    this.list.remove(i);
                    if (i == i2) {
                        break;
                    } else {
                        i--;
                    }
                }
            }
            this.end = this.start;
        }

        @Override // java.util.List
        public ListIterator listIterator() {
            return new MutableObjectListIterator(this, 0);
        }

        @Override // java.util.List
        public ListIterator listIterator(int i) {
            return new MutableObjectListIterator(this, i);
        }

        @Override // java.util.List, java.util.Collection
        public boolean remove(Object obj) {
            int i = this.end;
            for (int i2 = this.start; i2 < i; i2++) {
                if (Intrinsics.areEqual(this.list.get(i2), obj)) {
                    this.list.remove(i2);
                    this.end--;
                    return true;
                }
            }
            return false;
        }

        @Override // java.util.List, java.util.Collection
        public boolean removeAll(Collection elements) {
            Intrinsics.checkNotNullParameter(elements, "elements");
            int i = this.end;
            Iterator it = elements.iterator();
            while (it.hasNext()) {
                remove(it.next());
            }
            return i != this.end;
        }

        public Object removeAt(int i) {
            ObjectListKt.checkIndex(this, i);
            Object objRemove = this.list.remove(i + this.start);
            this.end--;
            return objRemove;
        }

        @Override // java.util.List, java.util.Collection
        public boolean retainAll(Collection elements) {
            Intrinsics.checkNotNullParameter(elements, "elements");
            int i = this.end;
            int i2 = i - 1;
            int i3 = this.start;
            if (i3 <= i2) {
                while (true) {
                    if (!elements.contains(this.list.get(i2))) {
                        this.list.remove(i2);
                        this.end--;
                    }
                    if (i2 == i3) {
                        break;
                    }
                    i2--;
                }
            }
            return i != this.end;
        }

        @Override // java.util.List
        public Object set(int i, Object obj) {
            ObjectListKt.checkIndex(this, i);
            return this.list.set(i + this.start, obj);
        }

        @Override // java.util.List
        public List subList(int i, int i2) {
            ObjectListKt.checkSubIndex(this, i, i2);
            return new SubList(this, i, i2);
        }
    }

    public final void plusAssign(Iterable<? extends E> elements) {
        Intrinsics.checkNotNullParameter(elements, "elements");
        Iterator<? extends E> it = elements.iterator();
        while (it.hasNext()) {
            add(it.next());
        }
    }

    public final void minusAssign(E[] elements) {
        Intrinsics.checkNotNullParameter(elements, "elements");
        for (E e : elements) {
            remove(e);
        }
    }

    public final void minusAssign(Iterable<? extends E> elements) {
        Intrinsics.checkNotNullParameter(elements, "elements");
        Iterator<? extends E> it = elements.iterator();
        while (it.hasNext()) {
            remove(it.next());
        }
    }
}
