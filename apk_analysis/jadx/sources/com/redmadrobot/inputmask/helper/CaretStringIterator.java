package com.redmadrobot.inputmask.helper;

import com.redmadrobot.inputmask.model.CaretString;
import com.scanflow.datacapture.barinternal.kotlin.NoWhenBranchMatchedException;
import com.scanflow.datacapture.barinternal.kotlin.TypeCastException;
import kotlin.jvm.internal.DefaultConstructorMarker;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: CaretStringIterator.kt */
/* JADX INFO: loaded from: classes3.dex */
public class CaretStringIterator {
    private final CaretString caretString;
    private int currentIndex;

    public CaretStringIterator(CaretString caretString, int i) {
        Intrinsics.checkParameterIsNotNull(caretString, "caretString");
        this.caretString = caretString;
        this.currentIndex = i;
    }

    protected final CaretString getCaretString() {
        return this.caretString;
    }

    public /* synthetic */ CaretStringIterator(CaretString caretString, int i, int i2, DefaultConstructorMarker defaultConstructorMarker) {
        this(caretString, (i2 & 2) != 0 ? 0 : i);
    }

    protected final int getCurrentIndex() {
        return this.currentIndex;
    }

    protected final void setCurrentIndex(int i) {
        this.currentIndex = i;
    }

    public boolean insertionAffectsCaret() {
        CaretString.CaretGravity caretGravity = this.caretString.getCaretGravity();
        if (caretGravity instanceof CaretString.CaretGravity.BACKWARD) {
            return this.currentIndex < this.caretString.getCaretPosition();
        }
        if (caretGravity instanceof CaretString.CaretGravity.FORWARD) {
            return this.currentIndex <= this.caretString.getCaretPosition() || (this.currentIndex == 0 && this.caretString.getCaretPosition() == 0);
        }
        throw new NoWhenBranchMatchedException();
    }

    public boolean deletionAffectsCaret() {
        return this.currentIndex < this.caretString.getCaretPosition();
    }

    public Character next() {
        if (this.currentIndex >= this.caretString.getString().length()) {
            return null;
        }
        String string = this.caretString.getString();
        if (string == null) {
            throw new TypeCastException("null cannot be cast to non-null type java.lang.String");
        }
        char[] charArray = string.toCharArray();
        Intrinsics.checkExpressionValueIsNotNull(charArray, "(this as java.lang.String).toCharArray()");
        int i = this.currentIndex;
        char c = charArray[i];
        this.currentIndex = i + 1;
        return Character.valueOf(c);
    }
}
