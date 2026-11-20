package com.redmadrobot.inputmask.helper;

import com.redmadrobot.inputmask.model.CaretString;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: RTLCaretStringIterator.kt */
/* JADX INFO: loaded from: classes3.dex */
public final class RTLCaretStringIterator extends CaretStringIterator {
    /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
    public RTLCaretStringIterator(CaretString caretString) {
        super(caretString, 0, 2, null);
        Intrinsics.checkParameterIsNotNull(caretString, "caretString");
    }

    @Override // com.redmadrobot.inputmask.helper.CaretStringIterator
    public boolean insertionAffectsCaret() {
        return getCurrentIndex() <= getCaretString().getCaretPosition();
    }
}
