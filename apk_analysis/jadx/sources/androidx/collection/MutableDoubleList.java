package androidx.collection;

import androidx.collection.internal.RuntimeHelpersKt;
import com.scanflow.datacapture.barinternal.kotlin.collections.ArraysKt;
import java.util.Arrays;
import kotlin.jvm.internal.DefaultConstructorMarker;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: DoubleList.kt */
/* JADX INFO: loaded from: classes.dex */
public final class MutableDoubleList extends DoubleList {
    public MutableDoubleList() {
        this(0, 1, null);
    }

    public final void minusAssign(DoubleList elements) {
        Intrinsics.checkNotNullParameter(elements, "elements");
        double[] dArr = elements.content;
        int i = elements._size;
        for (int i2 = 0; i2 < i; i2++) {
            remove(dArr[i2]);
        }
    }

    public MutableDoubleList(int i) {
        super(i, null);
    }

    public /* synthetic */ MutableDoubleList(int i, int i2, DefaultConstructorMarker defaultConstructorMarker) {
        this((i2 & 1) != 0 ? 16 : i);
    }

    public final int getCapacity() {
        return this.content.length;
    }

    public final boolean add(double d) {
        ensureCapacity(this._size + 1);
        double[] dArr = this.content;
        int i = this._size;
        dArr[i] = d;
        this._size = i + 1;
        return true;
    }

    public final void add(int i, double d) {
        if (i < 0 || i > this._size) {
            RuntimeHelpersKt.throwIndexOutOfBoundsException("Index must be between 0 and size");
        }
        ensureCapacity(this._size + 1);
        double[] dArr = this.content;
        int i2 = this._size;
        if (i != i2) {
            ArraysKt.copyInto(dArr, dArr, i + 1, i, i2);
        }
        dArr[i] = d;
        this._size++;
    }

    public final boolean addAll(int i, double[] elements) {
        Intrinsics.checkNotNullParameter(elements, "elements");
        if (i < 0 || i > this._size) {
            RuntimeHelpersKt.throwIndexOutOfBoundsException("");
        }
        if (elements.length == 0) {
            return false;
        }
        ensureCapacity(this._size + elements.length);
        double[] dArr = this.content;
        int i2 = this._size;
        if (i != i2) {
            ArraysKt.copyInto(dArr, dArr, elements.length + i, i, i2);
        }
        ArraysKt.copyInto$default(elements, dArr, i, 0, 0, 12, (Object) null);
        this._size += elements.length;
        return true;
    }

    public final boolean addAll(int i, DoubleList elements) {
        Intrinsics.checkNotNullParameter(elements, "elements");
        if (i < 0 || i > this._size) {
            RuntimeHelpersKt.throwIndexOutOfBoundsException("");
        }
        int i2 = elements._size;
        if (i2 == 0) {
            return false;
        }
        ensureCapacity(this._size + i2);
        double[] dArr = this.content;
        int i3 = this._size;
        if (i != i3) {
            ArraysKt.copyInto(dArr, dArr, elements._size + i, i, i3);
        }
        ArraysKt.copyInto(elements.content, dArr, i, 0, elements._size);
        this._size += elements._size;
        return true;
    }

    public final boolean addAll(DoubleList elements) {
        Intrinsics.checkNotNullParameter(elements, "elements");
        return addAll(this._size, elements);
    }

    public final boolean addAll(double[] elements) {
        Intrinsics.checkNotNullParameter(elements, "elements");
        return addAll(this._size, elements);
    }

    public final void plusAssign(DoubleList elements) {
        Intrinsics.checkNotNullParameter(elements, "elements");
        addAll(this._size, elements);
    }

    public final void plusAssign(double[] elements) {
        Intrinsics.checkNotNullParameter(elements, "elements");
        addAll(this._size, elements);
    }

    public final void clear() {
        this._size = 0;
    }

    public final void trim(int i) {
        int iMax = Math.max(i, this._size);
        double[] dArr = this.content;
        if (dArr.length > iMax) {
            double[] dArrCopyOf = Arrays.copyOf(dArr, iMax);
            Intrinsics.checkNotNullExpressionValue(dArrCopyOf, "copyOf(...)");
            this.content = dArrCopyOf;
        }
    }

    public final void ensureCapacity(int i) {
        double[] dArr = this.content;
        if (dArr.length < i) {
            double[] dArrCopyOf = Arrays.copyOf(dArr, Math.max(i, (dArr.length * 3) / 2));
            Intrinsics.checkNotNullExpressionValue(dArrCopyOf, "copyOf(...)");
            this.content = dArrCopyOf;
        }
    }

    public final void plusAssign(double d) {
        add(d);
    }

    public final void minusAssign(double d) {
        remove(d);
    }

    public final boolean remove(double d) {
        int iIndexOf = indexOf(d);
        if (iIndexOf < 0) {
            return false;
        }
        removeAt(iIndexOf);
        return true;
    }

    public final boolean removeAll(double[] elements) {
        Intrinsics.checkNotNullParameter(elements, "elements");
        int i = this._size;
        for (double d : elements) {
            remove(d);
        }
        return i != this._size;
    }

    public final boolean removeAll(DoubleList elements) {
        Intrinsics.checkNotNullParameter(elements, "elements");
        int i = this._size;
        int i2 = elements._size - 1;
        if (i2 >= 0) {
            int i3 = 0;
            while (true) {
                remove(elements.get(i3));
                if (i3 == i2) {
                    break;
                }
                i3++;
            }
        }
        return i != this._size;
    }

    public final double removeAt(int i) {
        if (i < 0 || i >= this._size) {
            RuntimeHelpersKt.throwIndexOutOfBoundsException("Index must be between 0 and size");
        }
        double[] dArr = this.content;
        double d = dArr[i];
        int i2 = this._size;
        if (i != i2 - 1) {
            ArraysKt.copyInto(dArr, dArr, i, i + 1, i2);
        }
        this._size--;
        return d;
    }

    public final void removeRange(int i, int i2) {
        int i3;
        if (i < 0 || i > (i3 = this._size) || i2 < 0 || i2 > i3) {
            RuntimeHelpersKt.throwIndexOutOfBoundsException("Index must be between 0 and size");
        }
        if (i2 < i) {
            RuntimeHelpersKt.throwIllegalArgumentException("The end index must be < start index");
        }
        if (i2 != i) {
            int i4 = this._size;
            if (i2 < i4) {
                double[] dArr = this.content;
                ArraysKt.copyInto(dArr, dArr, i, i2, i4);
            }
            this._size -= i2 - i;
        }
    }

    public final boolean retainAll(double[] elements) {
        Intrinsics.checkNotNullParameter(elements, "elements");
        int i = this._size;
        double[] dArr = this.content;
        int i2 = i - 1;
        while (true) {
            int i3 = -1;
            if (-1 >= i2) {
                break;
            }
            double d = dArr[i2];
            int length = elements.length;
            for (int i4 = 0; i4 < length; i4++) {
                if (elements[i4] == d) {
                    i3 = i4;
                    break;
                }
            }
            if (i3 < 0) {
                removeAt(i2);
            }
            i2--;
        }
        return i != this._size;
    }

    public final boolean retainAll(DoubleList elements) {
        Intrinsics.checkNotNullParameter(elements, "elements");
        int i = this._size;
        double[] dArr = this.content;
        for (int i2 = i - 1; -1 < i2; i2--) {
            if (!elements.contains(dArr[i2])) {
                removeAt(i2);
            }
        }
        return i != this._size;
    }

    public final double set(int i, double d) {
        if (i < 0 || i >= this._size) {
            RuntimeHelpersKt.throwIndexOutOfBoundsException("Index must be between 0 and size");
        }
        double[] dArr = this.content;
        double d2 = dArr[i];
        dArr[i] = d;
        return d2;
    }

    public final void sort() {
        int i = this._size;
        if (i == 0) {
            return;
        }
        ArraysKt.sort(this.content, 0, i);
    }

    public final void sortDescending() {
        int i = this._size;
        if (i == 0) {
            return;
        }
        ArraysKt.sortDescending(this.content, 0, i);
    }

    public final void minusAssign(double[] elements) {
        Intrinsics.checkNotNullParameter(elements, "elements");
        for (double d : elements) {
            remove(d);
        }
    }
}
