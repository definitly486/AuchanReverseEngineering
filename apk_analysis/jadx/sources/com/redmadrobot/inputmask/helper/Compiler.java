package com.redmadrobot.inputmask.helper;

import com.redmadrobot.inputmask.model.Notation;
import com.redmadrobot.inputmask.model.State;
import com.redmadrobot.inputmask.model.state.EOLState;
import com.redmadrobot.inputmask.model.state.FixedState;
import com.redmadrobot.inputmask.model.state.FreeState;
import com.redmadrobot.inputmask.model.state.OptionalValueState;
import com.redmadrobot.inputmask.model.state.ValueState;
import com.scanflow.datacapture.barinternal.kotlin.text.StringsKt;
import java.util.List;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: Compiler.kt */
/* JADX INFO: loaded from: classes3.dex */
public final class Compiler {
    private final List<Notation> customNotations;

    /* JADX INFO: compiled from: Compiler.kt */
    public static final class FormatError extends Exception {
    }

    public Compiler(List<Notation> customNotations) {
        Intrinsics.checkParameterIsNotNull(customNotations, "customNotations");
        this.customNotations = customNotations;
    }

    public final State compile(String formatString) {
        Intrinsics.checkParameterIsNotNull(formatString, "formatString");
        return compile(new FormatSanitizer().sanitize(formatString), false, false, null);
    }

    private final State compile(String str, boolean z, boolean z2, Character ch) {
        if (str.length() == 0) {
            return new EOLState();
        }
        char cFirst = StringsKt.first(str);
        if (cFirst != '{') {
            if (cFirst != '}') {
                switch (cFirst) {
                    case '[':
                        if (ch == null || '\\' != ch.charValue()) {
                            return compile(StringsKt.drop(str, 1), true, false, Character.valueOf(cFirst));
                        }
                        break;
                    case '\\':
                        if (ch == null || '\\' != ch.charValue()) {
                            return compile(StringsKt.drop(str, 1), z, z2, Character.valueOf(cFirst));
                        }
                        break;
                    case ']':
                        if (ch == null || '\\' != ch.charValue()) {
                            return compile(StringsKt.drop(str, 1), false, false, Character.valueOf(cFirst));
                        }
                        break;
                }
            } else if (ch == null || '\\' != ch.charValue()) {
                return compile(StringsKt.drop(str, 1), false, false, Character.valueOf(cFirst));
            }
        } else if (ch == null || '\\' != ch.charValue()) {
            return compile(StringsKt.drop(str, 1), false, true, Character.valueOf(cFirst));
        }
        if (!z) {
            if (z2) {
                return new FixedState(compile(StringsKt.drop(str, 1), false, true, Character.valueOf(cFirst)), cFirst);
            }
            return new FreeState(compile(StringsKt.drop(str, 1), false, false, Character.valueOf(cFirst)), cFirst);
        }
        if (cFirst == '-') {
            return new OptionalValueState(compile(StringsKt.drop(str, 1), true, false, Character.valueOf(cFirst)), new OptionalValueState.StateType.AlphaNumeric());
        }
        if (cFirst == '0') {
            return new ValueState(compile(StringsKt.drop(str, 1), true, false, Character.valueOf(cFirst)), new ValueState.StateType.Numeric());
        }
        if (cFirst == '9') {
            return new OptionalValueState(compile(StringsKt.drop(str, 1), true, false, Character.valueOf(cFirst)), new OptionalValueState.StateType.Numeric());
        }
        if (cFirst == 'A') {
            return new ValueState(compile(StringsKt.drop(str, 1), true, false, Character.valueOf(cFirst)), new ValueState.StateType.Literal());
        }
        if (cFirst == '_') {
            return new ValueState(compile(StringsKt.drop(str, 1), true, false, Character.valueOf(cFirst)), new ValueState.StateType.AlphaNumeric());
        }
        if (cFirst == 'a') {
            return new OptionalValueState(compile(StringsKt.drop(str, 1), true, false, Character.valueOf(cFirst)), new OptionalValueState.StateType.Literal());
        }
        if (cFirst == 8230) {
            return new ValueState(determineInheritedType(ch));
        }
        return compileWithCustomNotations(cFirst, str);
    }

    private final ValueState.StateType determineInheritedType(Character ch) {
        if ((ch != null && ch.charValue() == '0') || (ch != null && ch.charValue() == '9')) {
            return new ValueState.StateType.Numeric();
        }
        if ((ch != null && ch.charValue() == 'A') || (ch != null && ch.charValue() == 'a')) {
            return new ValueState.StateType.Literal();
        }
        if ((ch != null && ch.charValue() == '_') || (ch != null && ch.charValue() == '-')) {
            return new ValueState.StateType.AlphaNumeric();
        }
        if (ch != null && ch.charValue() == 8230) {
            return new ValueState.StateType.AlphaNumeric();
        }
        return (ch != null && ch.charValue() == '[') ? new ValueState.StateType.AlphaNumeric() : determineTypeWithCustomNotations(ch);
    }

    private final State compileWithCustomNotations(char c, String str) throws FormatError {
        for (Notation notation : this.customNotations) {
            if (notation.getCharacter() == c) {
                if (notation.isOptional()) {
                    return new OptionalValueState(compile(StringsKt.drop(str, 1), true, false, Character.valueOf(c)), new OptionalValueState.StateType.Custom(c, notation.getCharacterSet()));
                }
                return new ValueState(compile(StringsKt.drop(str, 1), true, false, Character.valueOf(c)), new ValueState.StateType.Custom(c, notation.getCharacterSet()));
            }
        }
        throw new FormatError();
    }

    private final ValueState.StateType determineTypeWithCustomNotations(Character ch) throws FormatError {
        for (Notation notation : this.customNotations) {
            char character = notation.getCharacter();
            if (ch != null && character == ch.charValue()) {
                return new ValueState.StateType.Custom(ch.charValue(), notation.getCharacterSet());
            }
        }
        throw new FormatError();
    }
}
