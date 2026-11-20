package com.redmadrobot.inputmask.model.state;

import com.redmadrobot.inputmask.model.Next;
import com.redmadrobot.inputmask.model.State;
import com.scanflow.datacapture.barinternal.kotlin.NoWhenBranchMatchedException;
import com.scanflow.datacapture.barinternal.kotlin.text.StringsKt;
import kotlin.jvm.internal.DefaultConstructorMarker;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: OptionalValueState.kt */
/* JADX INFO: loaded from: classes3.dex */
public final class OptionalValueState extends State {
    private final StateType type;

    /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
    public OptionalValueState(State child, StateType type) {
        super(child);
        Intrinsics.checkParameterIsNotNull(child, "child");
        Intrinsics.checkParameterIsNotNull(type, "type");
        this.type = type;
    }

    public final StateType getType() {
        return this.type;
    }

    /* JADX INFO: compiled from: OptionalValueState.kt */
    public static abstract class StateType {

        /* JADX INFO: compiled from: OptionalValueState.kt */
        public static final class Numeric extends StateType {
            public Numeric() {
                super(null);
            }
        }

        private StateType() {
        }

        public /* synthetic */ StateType(DefaultConstructorMarker defaultConstructorMarker) {
            this();
        }

        /* JADX INFO: compiled from: OptionalValueState.kt */
        public static final class Literal extends StateType {
            public Literal() {
                super(null);
            }
        }

        /* JADX INFO: compiled from: OptionalValueState.kt */
        public static final class AlphaNumeric extends StateType {
            public AlphaNumeric() {
                super(null);
            }
        }

        /* JADX INFO: compiled from: OptionalValueState.kt */
        public static final class Custom extends StateType {
            private final char character;
            private final String characterSet;

            /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
            public Custom(char c, String characterSet) {
                super(null);
                Intrinsics.checkParameterIsNotNull(characterSet, "characterSet");
                this.character = c;
                this.characterSet = characterSet;
            }

            public final char getCharacter() {
                return this.character;
            }

            public final String getCharacterSet() {
                return this.characterSet;
            }
        }
    }

    private final boolean accepts(char c) {
        StateType stateType = this.type;
        if (stateType instanceof StateType.Numeric) {
            return Character.isDigit(c);
        }
        if (stateType instanceof StateType.Literal) {
            return Character.isLetter(c);
        }
        if (stateType instanceof StateType.AlphaNumeric) {
            return Character.isLetterOrDigit(c);
        }
        if (stateType instanceof StateType.Custom) {
            return StringsKt.contains$default((CharSequence) ((StateType.Custom) stateType).getCharacterSet(), c, false, 2, (Object) null);
        }
        throw new NoWhenBranchMatchedException();
    }

    @Override // com.redmadrobot.inputmask.model.State
    public Next accept(char c) {
        if (accepts(c)) {
            return new Next(nextState(), Character.valueOf(c), true, Character.valueOf(c));
        }
        return new Next(nextState(), null, false, null);
    }

    @Override // com.redmadrobot.inputmask.model.State
    public String toString() {
        StateType stateType = this.type;
        if (stateType instanceof StateType.Literal) {
            StringBuilder sb = new StringBuilder();
            sb.append("[a] -> ");
            sb.append(getChild() != null ? getChild().toString() : "null");
            return sb.toString();
        }
        if (stateType instanceof StateType.Numeric) {
            StringBuilder sb2 = new StringBuilder();
            sb2.append("[9] -> ");
            sb2.append(getChild() != null ? getChild().toString() : "null");
            return sb2.toString();
        }
        if (stateType instanceof StateType.AlphaNumeric) {
            StringBuilder sb3 = new StringBuilder();
            sb3.append("[-] -> ");
            sb3.append(getChild() != null ? getChild().toString() : "null");
            return sb3.toString();
        }
        if (!(stateType instanceof StateType.Custom)) {
            throw new NoWhenBranchMatchedException();
        }
        StringBuilder sb4 = new StringBuilder();
        sb4.append("[");
        sb4.append(((StateType.Custom) this.type).getCharacter());
        sb4.append("] -> ");
        sb4.append(getChild() != null ? getChild().toString() : "null");
        return sb4.toString();
    }
}
