package androidx.collection;

import androidx.collection.internal.RuntimeHelpersKt;
import com.scanflow.datacapture.barinternal.kotlin.Unit;
import com.scanflow.datacapture.barinternal.kotlin.jvm.functions.Function3;
import com.scanflow.datacapture.barinternal.kotlin.ranges.IntRange;
import com.scanflow.datacapture.barinternal.kotlin.ranges.RangesKt;
import java.util.NoSuchElementException;
import kotlin.jvm.functions.Function1;
import kotlin.jvm.functions.Function2;
import kotlin.jvm.internal.DefaultConstructorMarker;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: DoubleList.kt */
/* JADX INFO: loaded from: classes.dex */
public abstract class DoubleList {
    public int _size;
    public double[] content;

    public /* synthetic */ DoubleList(int i, DefaultConstructorMarker defaultConstructorMarker) {
        this(i);
    }

    public final int binarySearch(int i) {
        return binarySearch$default(this, i, 0, 0, 6, null);
    }

    public final int binarySearch(int i, int i2) {
        return binarySearch$default(this, i, i2, 0, 4, null);
    }

    public final String joinToString() {
        return joinToString$default(this, null, null, null, 0, null, 31, null);
    }

    public final String joinToString(CharSequence separator) {
        Intrinsics.checkNotNullParameter(separator, "separator");
        return joinToString$default(this, separator, null, null, 0, null, 30, null);
    }

    public final String joinToString(CharSequence separator, CharSequence prefix) {
        Intrinsics.checkNotNullParameter(separator, "separator");
        Intrinsics.checkNotNullParameter(prefix, "prefix");
        return joinToString$default(this, separator, prefix, null, 0, null, 28, null);
    }

    public final String joinToString(CharSequence separator, CharSequence prefix, CharSequence postfix) {
        Intrinsics.checkNotNullParameter(separator, "separator");
        Intrinsics.checkNotNullParameter(prefix, "prefix");
        Intrinsics.checkNotNullParameter(postfix, "postfix");
        return joinToString$default(this, separator, prefix, postfix, 0, null, 24, null);
    }

    public final String joinToString(CharSequence separator, CharSequence prefix, CharSequence postfix, int i) {
        Intrinsics.checkNotNullParameter(separator, "separator");
        Intrinsics.checkNotNullParameter(prefix, "prefix");
        Intrinsics.checkNotNullParameter(postfix, "postfix");
        return joinToString$default(this, separator, prefix, postfix, i, null, 16, null);
    }

    private DoubleList(int i) {
        double[] emptyDoubleArray;
        if (i == 0) {
            emptyDoubleArray = DoubleSetKt.getEmptyDoubleArray();
        } else {
            emptyDoubleArray = new double[i];
        }
        this.content = emptyDoubleArray;
    }

    public static /* synthetic */ int binarySearch$default(DoubleList doubleList, int i, int i2, int i3, int i4, Object obj) {
        if (obj != null) {
            throw new UnsupportedOperationException("Super calls with default arguments not supported in this target, function: binarySearch");
        }
        if ((i4 & 2) != 0) {
            i2 = 0;
        }
        if ((i4 & 4) != 0) {
            i3 = doubleList._size;
        }
        return doubleList.binarySearch(i, i2, i3);
    }

    public final int getSize() {
        return this._size;
    }

    public final int getLastIndex() {
        return this._size - 1;
    }

    public final boolean containsAll(DoubleList elements) {
        Intrinsics.checkNotNullParameter(elements, "elements");
        IntRange intRangeUntil = RangesKt.until(0, elements._size);
        int first = intRangeUntil.getFirst();
        int last = intRangeUntil.getLast();
        if (first > last) {
            return true;
        }
        while (contains(elements.get(first))) {
            if (first == last) {
                return true;
            }
            first++;
        }
        return false;
    }

    public final IntRange getIndices() {
        return RangesKt.until(0, this._size);
    }

    public final int count() {
        return this._size;
    }

    public final boolean any(Function1<? super Double, Boolean> predicate) {
        Intrinsics.checkNotNullParameter(predicate, "predicate");
        double[] dArr = this.content;
        int i = this._size;
        for (int i2 = 0; i2 < i; i2++) {
            if (predicate.invoke(Double.valueOf(dArr[i2])).booleanValue()) {
                return true;
            }
        }
        return false;
    }

    public final boolean contains(double d) {
        double[] dArr = this.content;
        int i = this._size;
        for (int i2 = 0; i2 < i; i2++) {
            if (dArr[i2] == d) {
                return true;
            }
        }
        return false;
    }

    public final int count(Function1<? super Double, Boolean> predicate) {
        Intrinsics.checkNotNullParameter(predicate, "predicate");
        double[] dArr = this.content;
        int i = this._size;
        int i2 = 0;
        for (int i3 = 0; i3 < i; i3++) {
            if (predicate.invoke(Double.valueOf(dArr[i3])).booleanValue()) {
                i2++;
            }
        }
        return i2;
    }

    public final double first(Function1<? super Double, Boolean> predicate) {
        Intrinsics.checkNotNullParameter(predicate, "predicate");
        double[] dArr = this.content;
        int i = this._size;
        for (int i2 = 0; i2 < i; i2++) {
            double d = dArr[i2];
            if (predicate.invoke(Double.valueOf(d)).booleanValue()) {
                return d;
            }
        }
        throw new NoSuchElementException("DoubleList contains no element matching the predicate.");
    }

    public final <R> R fold(R r, Function2<? super R, ? super Double, ? extends R> operation) {
        Intrinsics.checkNotNullParameter(operation, "operation");
        double[] dArr = this.content;
        int i = this._size;
        for (int i2 = 0; i2 < i; i2++) {
            r = operation.invoke(r, Double.valueOf(dArr[i2]));
        }
        return r;
    }

    public final void forEach(Function1<? super Double, Unit> block) {
        Intrinsics.checkNotNullParameter(block, "block");
        double[] dArr = this.content;
        int i = this._size;
        for (int i2 = 0; i2 < i; i2++) {
            block.invoke(Double.valueOf(dArr[i2]));
        }
    }

    public int hashCode() {
        double[] dArr = this.content;
        int i = this._size;
        int iHashCode = 0;
        for (int i2 = 0; i2 < i; i2++) {
            iHashCode += Double.hashCode(dArr[i2]) * 31;
        }
        return iHashCode;
    }

    public final <R> R foldIndexed(R r, Function3 operation) {
        Intrinsics.checkNotNullParameter(operation, "operation");
        double[] dArr = this.content;
        int i = this._size;
        for (int i2 = 0; i2 < i; i2++) {
            R r2 = r;
            r = (R) operation.invoke(Integer.valueOf(i2), r2, Double.valueOf(dArr[i2]));
        }
        return r;
    }

    public final void forEachIndexed(Function2<? super Integer, ? super Double, Unit> block) {
        Intrinsics.checkNotNullParameter(block, "block");
        double[] dArr = this.content;
        int i = this._size;
        for (int i2 = 0; i2 < i; i2++) {
            block.invoke(Integer.valueOf(i2), Double.valueOf(dArr[i2]));
        }
    }

    public final int indexOf(double d) {
        double[] dArr = this.content;
        int i = this._size;
        for (int i2 = 0; i2 < i; i2++) {
            if (d == dArr[i2]) {
                return i2;
            }
        }
        return -1;
    }

    public final int indexOfFirst(Function1<? super Double, Boolean> predicate) {
        Intrinsics.checkNotNullParameter(predicate, "predicate");
        double[] dArr = this.content;
        int i = this._size;
        for (int i2 = 0; i2 < i; i2++) {
            if (predicate.invoke(Double.valueOf(dArr[i2])).booleanValue()) {
                return i2;
            }
        }
        return -1;
    }

    public final <R> R foldRight(R r, Function2<? super Double, ? super R, ? extends R> operation) {
        Intrinsics.checkNotNullParameter(operation, "operation");
        double[] dArr = this.content;
        int i = this._size;
        while (true) {
            i--;
            if (-1 >= i) {
                return r;
            }
            r = operation.invoke(Double.valueOf(dArr[i]), r);
        }
    }

    public final void forEachReversed(Function1<? super Double, Unit> block) {
        Intrinsics.checkNotNullParameter(block, "block");
        double[] dArr = this.content;
        int i = this._size;
        while (true) {
            i--;
            if (-1 >= i) {
                return;
            } else {
                block.invoke(Double.valueOf(dArr[i]));
            }
        }
    }

    public final double last(Function1<? super Double, Boolean> predicate) {
        double d;
        Intrinsics.checkNotNullParameter(predicate, "predicate");
        double[] dArr = this.content;
        int i = this._size;
        do {
            i--;
            if (-1 < i) {
                d = dArr[i];
            } else {
                throw new NoSuchElementException("DoubleList contains no element matching the predicate.");
            }
        } while (!predicate.invoke(Double.valueOf(d)).booleanValue());
        return d;
    }

    public final boolean reversedAny(Function1<? super Double, Boolean> predicate) {
        Intrinsics.checkNotNullParameter(predicate, "predicate");
        double[] dArr = this.content;
        for (int i = this._size - 1; -1 < i; i--) {
            if (predicate.invoke(Double.valueOf(dArr[i])).booleanValue()) {
                return true;
            }
        }
        return false;
    }

    public final <R> R foldRightIndexed(R r, Function3 operation) {
        Intrinsics.checkNotNullParameter(operation, "operation");
        double[] dArr = this.content;
        int i = this._size;
        while (true) {
            i--;
            if (-1 >= i) {
                return r;
            }
            r = (R) operation.invoke(Integer.valueOf(i), Double.valueOf(dArr[i]), r);
        }
    }

    public final void forEachReversedIndexed(Function2<? super Integer, ? super Double, Unit> block) {
        Intrinsics.checkNotNullParameter(block, "block");
        double[] dArr = this.content;
        int i = this._size;
        while (true) {
            i--;
            if (-1 >= i) {
                return;
            } else {
                block.invoke(Integer.valueOf(i), Double.valueOf(dArr[i]));
            }
        }
    }

    public final int indexOfLast(Function1<? super Double, Boolean> predicate) {
        Intrinsics.checkNotNullParameter(predicate, "predicate");
        double[] dArr = this.content;
        int i = this._size;
        do {
            i--;
            if (-1 >= i) {
                return -1;
            }
        } while (!predicate.invoke(Double.valueOf(dArr[i])).booleanValue());
        return i;
    }

    public final int lastIndexOf(double d) {
        double[] dArr = this.content;
        int i = this._size;
        do {
            i--;
            if (-1 >= i) {
                return -1;
            }
        } while (dArr[i] != d);
        return i;
    }

    public final double get(int i) {
        if (i < 0 || i >= this._size) {
            RuntimeHelpersKt.throwIndexOutOfBoundsException("Index must be between 0 and size");
        }
        return this.content[i];
    }

    public final double elementAt(int i) {
        if (i < 0 || i >= this._size) {
            RuntimeHelpersKt.throwIndexOutOfBoundsException("Index must be between 0 and size");
        }
        return this.content[i];
    }

    public final double elementAtOrElse(int i, Function1<? super Integer, Double> defaultValue) {
        Intrinsics.checkNotNullParameter(defaultValue, "defaultValue");
        if (i < 0 || i >= this._size) {
            return defaultValue.invoke(Integer.valueOf(i)).doubleValue();
        }
        return this.content[i];
    }

    public final double first() {
        if (this._size == 0) {
            RuntimeHelpersKt.throwNoSuchElementException("DoubleList is empty.");
        }
        return this.content[0];
    }

    public final boolean isEmpty() {
        return this._size == 0;
    }

    public final double last() {
        if (this._size == 0) {
            RuntimeHelpersKt.throwNoSuchElementException("DoubleList is empty.");
        }
        return this.content[this._size - 1];
    }

    public final boolean none() {
        return this._size == 0;
    }

    public final boolean any() {
        return this._size != 0;
    }

    public final boolean isNotEmpty() {
        return this._size != 0;
    }

    public final int binarySearch(int i, int i2, int i3) {
        if (i2 < 0 || i2 >= i3 || i3 > this._size) {
            RuntimeHelpersKt.throwIndexOutOfBoundsException("");
        }
        int i4 = i3 - 1;
        while (i2 <= i4) {
            int i5 = (i2 + i4) >>> 1;
            double d = this.content[i5];
            double d2 = i;
            if (d < d2) {
                i2 = i5 + 1;
            } else {
                if (d <= d2) {
                    return i5;
                }
                i4 = i5 - 1;
            }
        }
        return -(i2 + 1);
    }

    public static /* synthetic */ String joinToString$default(DoubleList doubleList, CharSequence charSequence, CharSequence charSequence2, CharSequence charSequence3, int i, CharSequence charSequence4, int i2, Object obj) {
        if (obj != null) {
            throw new UnsupportedOperationException("Super calls with default arguments not supported in this target, function: joinToString");
        }
        if ((i2 & 1) != 0) {
            charSequence = ", ";
        }
        if ((i2 & 2) != 0) {
            charSequence2 = "";
        }
        if ((i2 & 4) != 0) {
            charSequence3 = "";
        }
        if ((i2 & 8) != 0) {
            i = -1;
        }
        if ((i2 & 16) != 0) {
            charSequence4 = "...";
        }
        CharSequence charSequence5 = charSequence4;
        CharSequence charSequence6 = charSequence3;
        return doubleList.joinToString(charSequence, charSequence2, charSequence6, i, charSequence5);
    }

    public final String joinToString(CharSequence separator, CharSequence prefix, CharSequence postfix, int i, CharSequence truncated) {
        Intrinsics.checkNotNullParameter(separator, "separator");
        Intrinsics.checkNotNullParameter(prefix, "prefix");
        Intrinsics.checkNotNullParameter(postfix, "postfix");
        Intrinsics.checkNotNullParameter(truncated, "truncated");
        StringBuilder sb = new StringBuilder();
        sb.append(prefix);
        double[] dArr = this.content;
        int i2 = this._size;
        for (int i3 = 0; i3 < i2; i3++) {
            double d = dArr[i3];
            if (i3 == i) {
                sb.append(truncated);
                String string = sb.toString();
                Intrinsics.checkNotNullExpressionValue(string, "toString(...)");
                return string;
            }
            if (i3 != 0) {
                sb.append(separator);
            }
            sb.append(d);
        }
        sb.append(postfix);
        String string2 = sb.toString();
        Intrinsics.checkNotNullExpressionValue(string2, "toString(...)");
        return string2;
    }

    public final String joinToString(CharSequence separator, CharSequence prefix, CharSequence postfix, int i, CharSequence truncated, Function1<? super Double, ? extends CharSequence> transform) {
        Intrinsics.checkNotNullParameter(separator, "separator");
        Intrinsics.checkNotNullParameter(prefix, "prefix");
        Intrinsics.checkNotNullParameter(postfix, "postfix");
        Intrinsics.checkNotNullParameter(truncated, "truncated");
        Intrinsics.checkNotNullParameter(transform, "transform");
        StringBuilder sb = new StringBuilder();
        sb.append(prefix);
        double[] dArr = this.content;
        int i2 = this._size;
        for (int i3 = 0; i3 < i2; i3++) {
            double d = dArr[i3];
            if (i3 == i) {
                sb.append(truncated);
                String string = sb.toString();
                Intrinsics.checkNotNullExpressionValue(string, "toString(...)");
                return string;
            }
            if (i3 != 0) {
                sb.append(separator);
            }
            sb.append(transform.invoke(Double.valueOf(d)));
        }
        sb.append(postfix);
        String string2 = sb.toString();
        Intrinsics.checkNotNullExpressionValue(string2, "toString(...)");
        return string2;
    }

    public final String joinToString(CharSequence separator, CharSequence prefix, CharSequence postfix, int i, Function1<? super Double, ? extends CharSequence> transform) {
        Intrinsics.checkNotNullParameter(separator, "separator");
        Intrinsics.checkNotNullParameter(prefix, "prefix");
        Intrinsics.checkNotNullParameter(postfix, "postfix");
        Intrinsics.checkNotNullParameter(transform, "transform");
        StringBuilder sb = new StringBuilder();
        sb.append(prefix);
        double[] dArr = this.content;
        int i2 = this._size;
        for (int i3 = 0; i3 < i2; i3++) {
            double d = dArr[i3];
            if (i3 == i) {
                sb.append((CharSequence) "...");
                String string = sb.toString();
                Intrinsics.checkNotNullExpressionValue(string, "toString(...)");
                return string;
            }
            if (i3 != 0) {
                sb.append(separator);
            }
            sb.append(transform.invoke(Double.valueOf(d)));
        }
        sb.append(postfix);
        String string2 = sb.toString();
        Intrinsics.checkNotNullExpressionValue(string2, "toString(...)");
        return string2;
    }

    public final String joinToString(CharSequence separator, CharSequence prefix, CharSequence postfix, Function1<? super Double, ? extends CharSequence> transform) {
        Intrinsics.checkNotNullParameter(separator, "separator");
        Intrinsics.checkNotNullParameter(prefix, "prefix");
        Intrinsics.checkNotNullParameter(postfix, "postfix");
        Intrinsics.checkNotNullParameter(transform, "transform");
        StringBuilder sb = new StringBuilder();
        sb.append(prefix);
        double[] dArr = this.content;
        int i = this._size;
        for (int i2 = 0; i2 < i; i2++) {
            double d = dArr[i2];
            if (i2 == -1) {
                sb.append((CharSequence) "...");
                String string = sb.toString();
                Intrinsics.checkNotNullExpressionValue(string, "toString(...)");
                return string;
            }
            if (i2 != 0) {
                sb.append(separator);
            }
            sb.append(transform.invoke(Double.valueOf(d)));
        }
        sb.append(postfix);
        String string2 = sb.toString();
        Intrinsics.checkNotNullExpressionValue(string2, "toString(...)");
        return string2;
    }

    public final String joinToString(CharSequence separator, CharSequence prefix, Function1<? super Double, ? extends CharSequence> transform) {
        Intrinsics.checkNotNullParameter(separator, "separator");
        Intrinsics.checkNotNullParameter(prefix, "prefix");
        Intrinsics.checkNotNullParameter(transform, "transform");
        StringBuilder sb = new StringBuilder();
        sb.append(prefix);
        double[] dArr = this.content;
        int i = this._size;
        for (int i2 = 0; i2 < i; i2++) {
            double d = dArr[i2];
            if (i2 == -1) {
                sb.append((CharSequence) "...");
                String string = sb.toString();
                Intrinsics.checkNotNullExpressionValue(string, "toString(...)");
                return string;
            }
            if (i2 != 0) {
                sb.append(separator);
            }
            sb.append(transform.invoke(Double.valueOf(d)));
        }
        sb.append((CharSequence) "");
        String string2 = sb.toString();
        Intrinsics.checkNotNullExpressionValue(string2, "toString(...)");
        return string2;
    }

    public final String joinToString(CharSequence separator, Function1<? super Double, ? extends CharSequence> transform) {
        Intrinsics.checkNotNullParameter(separator, "separator");
        Intrinsics.checkNotNullParameter(transform, "transform");
        StringBuilder sb = new StringBuilder();
        sb.append((CharSequence) "");
        double[] dArr = this.content;
        int i = this._size;
        for (int i2 = 0; i2 < i; i2++) {
            double d = dArr[i2];
            if (i2 == -1) {
                sb.append((CharSequence) "...");
                String string = sb.toString();
                Intrinsics.checkNotNullExpressionValue(string, "toString(...)");
                return string;
            }
            if (i2 != 0) {
                sb.append(separator);
            }
            sb.append(transform.invoke(Double.valueOf(d)));
        }
        sb.append((CharSequence) "");
        String string2 = sb.toString();
        Intrinsics.checkNotNullExpressionValue(string2, "toString(...)");
        return string2;
    }

    public final String joinToString(Function1<? super Double, ? extends CharSequence> transform) {
        Intrinsics.checkNotNullParameter(transform, "transform");
        StringBuilder sb = new StringBuilder();
        sb.append((CharSequence) "");
        double[] dArr = this.content;
        int i = this._size;
        for (int i2 = 0; i2 < i; i2++) {
            double d = dArr[i2];
            if (i2 == -1) {
                sb.append((CharSequence) "...");
                String string = sb.toString();
                Intrinsics.checkNotNullExpressionValue(string, "toString(...)");
                return string;
            }
            if (i2 != 0) {
                sb.append((CharSequence) ", ");
            }
            sb.append(transform.invoke(Double.valueOf(d)));
        }
        sb.append((CharSequence) "");
        String string2 = sb.toString();
        Intrinsics.checkNotNullExpressionValue(string2, "toString(...)");
        return string2;
    }

    public boolean equals(Object obj) {
        if (obj instanceof DoubleList) {
            DoubleList doubleList = (DoubleList) obj;
            int i = doubleList._size;
            int i2 = this._size;
            if (i == i2) {
                double[] dArr = this.content;
                double[] dArr2 = doubleList.content;
                IntRange intRangeUntil = RangesKt.until(0, i2);
                int first = intRangeUntil.getFirst();
                int last = intRangeUntil.getLast();
                if (first > last) {
                    return true;
                }
                while (dArr[first] == dArr2[first]) {
                    if (first == last) {
                        return true;
                    }
                    first++;
                }
                return false;
            }
        }
        return false;
    }

    public String toString() {
        return joinToString$default(this, null, "[", "]", 0, null, 25, null);
    }
}
