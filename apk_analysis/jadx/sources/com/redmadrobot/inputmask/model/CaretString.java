package com.redmadrobot.inputmask.model;

import com.scanflow.datacapture.barinternal.kotlin.TypeCastException;
import com.scanflow.datacapture.barinternal.kotlin.text.StringsKt;
import kotlin.jvm.internal.DefaultConstructorMarker;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: CaretString.kt */
/* JADX INFO: loaded from: classes3.dex */
public final class CaretString {
    private final CaretGravity caretGravity;
    private final int caretPosition;
    private final String string;

    public static /* synthetic */ CaretString copy$default(CaretString caretString, String str, int i, CaretGravity caretGravity, int i2, Object obj) {
        if ((i2 & 1) != 0) {
            str = caretString.string;
        }
        if ((i2 & 2) != 0) {
            i = caretString.caretPosition;
        }
        if ((i2 & 4) != 0) {
            caretGravity = caretString.caretGravity;
        }
        return caretString.copy(str, i, caretGravity);
    }

    public final String component1() {
        return this.string;
    }

    public final int component2() {
        return this.caretPosition;
    }

    public final CaretGravity component3() {
        return this.caretGravity;
    }

    public final CaretString copy(String string, int i, CaretGravity caretGravity) {
        Intrinsics.checkParameterIsNotNull(string, "string");
        Intrinsics.checkParameterIsNotNull(caretGravity, "caretGravity");
        return new CaretString(string, i, caretGravity);
    }

    public boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (!(obj instanceof CaretString)) {
            return false;
        }
        CaretString caretString = (CaretString) obj;
        return Intrinsics.areEqual(this.string, caretString.string) && this.caretPosition == caretString.caretPosition && Intrinsics.areEqual(this.caretGravity, caretString.caretGravity);
    }

    public int hashCode() {
        String str = this.string;
        int iHashCode = (((str != null ? str.hashCode() : 0) * 31) + this.caretPosition) * 31;
        CaretGravity caretGravity = this.caretGravity;
        return iHashCode + (caretGravity != null ? caretGravity.hashCode() : 0);
    }

    public String toString() {
        return "CaretString(string=" + this.string + ", caretPosition=" + this.caretPosition + ", caretGravity=" + this.caretGravity + ")";
    }

    public CaretString(String string, int i, CaretGravity caretGravity) {
        Intrinsics.checkParameterIsNotNull(string, "string");
        Intrinsics.checkParameterIsNotNull(caretGravity, "caretGravity");
        this.string = string;
        this.caretPosition = i;
        this.caretGravity = caretGravity;
    }

    public final String getString() {
        return this.string;
    }

    public final int getCaretPosition() {
        return this.caretPosition;
    }

    public final CaretGravity getCaretGravity() {
        return this.caretGravity;
    }

    public final CaretString reversed() {
        String str = this.string;
        if (str != null) {
            return new CaretString(StringsKt.reversed(str).toString(), this.string.length() - this.caretPosition, this.caretGravity);
        }
        throw new TypeCastException("null cannot be cast to non-null type kotlin.CharSequence");
    }

    /* JADX INFO: compiled from: CaretString.kt */
    public static abstract class CaretGravity {

        /* JADX INFO: compiled from: CaretString.kt */
        public static final class FORWARD extends CaretGravity {
            private final boolean autocompleteValue;

            public FORWARD(boolean z) {
                super(null);
                this.autocompleteValue = z;
            }

            public final boolean getAutocompleteValue() {
                return this.autocompleteValue;
            }
        }

        private CaretGravity() {
        }

        public /* synthetic */ CaretGravity(DefaultConstructorMarker defaultConstructorMarker) {
            this();
        }

        /* JADX INFO: compiled from: CaretString.kt */
        public static final class BACKWARD extends CaretGravity {
            private final boolean autoskipValue;

            public BACKWARD(boolean z) {
                super(null);
                this.autoskipValue = z;
            }

            public final boolean getAutoskipValue() {
                return this.autoskipValue;
            }
        }

        public final boolean getAutocomplete() {
            if (this instanceof FORWARD) {
                return ((FORWARD) this).getAutocompleteValue();
            }
            return false;
        }

        public final boolean getAutoskip() {
            if (this instanceof BACKWARD) {
                return ((BACKWARD) this).getAutoskipValue();
            }
            return false;
        }
    }
}
