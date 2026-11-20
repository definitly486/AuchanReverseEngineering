package com.redmadrobot.inputmask.helper;

import com.redmadrobot.inputmask.model.CaretString;
import com.redmadrobot.inputmask.model.Next;
import com.redmadrobot.inputmask.model.Notation;
import com.redmadrobot.inputmask.model.State;
import com.redmadrobot.inputmask.model.state.EOLState;
import com.redmadrobot.inputmask.model.state.FixedState;
import com.redmadrobot.inputmask.model.state.FreeState;
import com.redmadrobot.inputmask.model.state.OptionalValueState;
import com.redmadrobot.inputmask.model.state.ValueState;
import com.scanflow.datacapture.barinternal.kotlin.NoWhenBranchMatchedException;
import com.scanflow.datacapture.barinternal.kotlin.TypeCastException;
import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import com.scanflow.datacapture.barinternal.kotlin.text.StringsKt;
import io.appmetrica.analytics.networktasks.internal.CommonUrlParts;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Stack;
import kotlin.jvm.internal.DefaultConstructorMarker;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: Mask.kt */
/* JADX INFO: loaded from: classes3.dex */
public class Mask {
    public static final Factory Factory = new Factory(null);
    private static final Map<String, Mask> cache = new HashMap();
    private final List<Notation> customNotations;
    private final State initialState;

    public Mask(String format, List<Notation> customNotations) {
        Intrinsics.checkParameterIsNotNull(format, "format");
        Intrinsics.checkParameterIsNotNull(customNotations, "customNotations");
        this.customNotations = customNotations;
        this.initialState = new Compiler(customNotations).compile(format);
    }

    protected final List<Notation> getCustomNotations() {
        return this.customNotations;
    }

    /* JADX WARN: 'this' call moved to the top of the method (can break code semantics) */
    public Mask(String format) {
        this(format, CollectionsKt.emptyList());
        Intrinsics.checkParameterIsNotNull(format, "format");
    }

    /* JADX INFO: compiled from: Mask.kt */
    public static final class Result {
        private final int affinity;
        private final boolean complete;
        private final String extractedValue;
        private final CaretString formattedText;

        public static /* synthetic */ Result copy$default(Result result, CaretString caretString, String str, int i, boolean z, int i2, Object obj) {
            if ((i2 & 1) != 0) {
                caretString = result.formattedText;
            }
            if ((i2 & 2) != 0) {
                str = result.extractedValue;
            }
            if ((i2 & 4) != 0) {
                i = result.affinity;
            }
            if ((i2 & 8) != 0) {
                z = result.complete;
            }
            return result.copy(caretString, str, i, z);
        }

        public final CaretString component1() {
            return this.formattedText;
        }

        public final String component2() {
            return this.extractedValue;
        }

        public final int component3() {
            return this.affinity;
        }

        public final boolean component4() {
            return this.complete;
        }

        public final Result copy(CaretString formattedText, String extractedValue, int i, boolean z) {
            Intrinsics.checkParameterIsNotNull(formattedText, "formattedText");
            Intrinsics.checkParameterIsNotNull(extractedValue, "extractedValue");
            return new Result(formattedText, extractedValue, i, z);
        }

        public boolean equals(Object obj) {
            if (this == obj) {
                return true;
            }
            if (!(obj instanceof Result)) {
                return false;
            }
            Result result = (Result) obj;
            return Intrinsics.areEqual(this.formattedText, result.formattedText) && Intrinsics.areEqual(this.extractedValue, result.extractedValue) && this.affinity == result.affinity && this.complete == result.complete;
        }

        /* JADX WARN: Multi-variable type inference failed */
        /* JADX WARN: Type inference failed for: r0v8, types: [int] */
        /* JADX WARN: Type inference failed for: r1v4, types: [int] */
        /* JADX WARN: Type inference failed for: r1v5 */
        /* JADX WARN: Type inference failed for: r1v7 */
        public int hashCode() {
            CaretString caretString = this.formattedText;
            int iHashCode = (caretString != null ? caretString.hashCode() : 0) * 31;
            String str = this.extractedValue;
            int iHashCode2 = (((iHashCode + (str != null ? str.hashCode() : 0)) * 31) + this.affinity) * 31;
            boolean z = this.complete;
            ?? r1 = z;
            if (z) {
                r1 = 1;
            }
            return iHashCode2 + r1;
        }

        public String toString() {
            return "Result(formattedText=" + this.formattedText + ", extractedValue=" + this.extractedValue + ", affinity=" + this.affinity + ", complete=" + this.complete + ")";
        }

        public Result(CaretString formattedText, String extractedValue, int i, boolean z) {
            Intrinsics.checkParameterIsNotNull(formattedText, "formattedText");
            Intrinsics.checkParameterIsNotNull(extractedValue, "extractedValue");
            this.formattedText = formattedText;
            this.extractedValue = extractedValue;
            this.affinity = i;
            this.complete = z;
        }

        public final CaretString getFormattedText() {
            return this.formattedText;
        }

        public final String getExtractedValue() {
            return this.extractedValue;
        }

        public final int getAffinity() {
            return this.affinity;
        }

        public final boolean getComplete() {
            return this.complete;
        }

        public final Result reversed() {
            CaretString caretStringReversed = this.formattedText.reversed();
            String str = this.extractedValue;
            if (str != null) {
                return new Result(caretStringReversed, StringsKt.reversed(str).toString(), this.affinity, this.complete);
            }
            throw new TypeCastException("null cannot be cast to non-null type kotlin.CharSequence");
        }
    }

    /* JADX INFO: compiled from: Mask.kt */
    public static final class Factory {
        private Factory() {
        }

        public /* synthetic */ Factory(DefaultConstructorMarker defaultConstructorMarker) {
            this();
        }

        public final Mask getOrCreate(String format, List<Notation> customNotations) {
            Intrinsics.checkParameterIsNotNull(format, "format");
            Intrinsics.checkParameterIsNotNull(customNotations, "customNotations");
            Mask mask = (Mask) Mask.cache.get(format);
            if (mask != null) {
                return mask;
            }
            Mask mask2 = new Mask(format, customNotations);
            Mask.cache.put(format, mask2);
            return mask2;
        }

        public final boolean isValid(String format, List<Notation> customNotations) {
            Intrinsics.checkParameterIsNotNull(format, "format");
            Intrinsics.checkParameterIsNotNull(customNotations, "customNotations");
            try {
                new Mask(format, customNotations);
                return true;
            } catch (Compiler.FormatError unused) {
                return false;
            }
        }
    }

    public Result apply(CaretString text) {
        Next nextAutocomplete;
        Intrinsics.checkParameterIsNotNull(text, "text");
        CaretStringIterator caretStringIteratorMakeIterator = makeIterator(text);
        int caretPosition = text.getCaretPosition();
        State state = this.initialState;
        AutocompletionStack autocompletionStack = new AutocompletionStack();
        boolean zInsertionAffectsCaret = caretStringIteratorMakeIterator.insertionAffectsCaret();
        boolean zDeletionAffectsCaret = caretStringIteratorMakeIterator.deletionAffectsCaret();
        Character next = caretStringIteratorMakeIterator.next();
        int i = 0;
        String strDropLast = "";
        String strDropLast2 = strDropLast;
        while (next != null) {
            Next nextAccept = state.accept(next.charValue());
            if (nextAccept != null) {
                if (zDeletionAffectsCaret) {
                    autocompletionStack.push(state.autocomplete());
                }
                state = nextAccept.getState();
                StringBuilder sb = new StringBuilder();
                sb.append(strDropLast);
                Object insert = nextAccept.getInsert();
                if (insert == null) {
                    insert = "";
                }
                sb.append(insert);
                strDropLast = sb.toString();
                StringBuilder sb2 = new StringBuilder();
                sb2.append(strDropLast2);
                Object value = nextAccept.getValue();
                if (value == null) {
                    value = "";
                }
                sb2.append(value);
                strDropLast2 = sb2.toString();
                if (nextAccept.getPass()) {
                    zInsertionAffectsCaret = caretStringIteratorMakeIterator.insertionAffectsCaret();
                    zDeletionAffectsCaret = caretStringIteratorMakeIterator.deletionAffectsCaret();
                    next = caretStringIteratorMakeIterator.next();
                    i++;
                } else if (zInsertionAffectsCaret && nextAccept.getInsert() != null) {
                    caretPosition++;
                }
            } else {
                if (zDeletionAffectsCaret) {
                    caretPosition--;
                }
                zInsertionAffectsCaret = caretStringIteratorMakeIterator.insertionAffectsCaret();
                zDeletionAffectsCaret = caretStringIteratorMakeIterator.deletionAffectsCaret();
                next = caretStringIteratorMakeIterator.next();
            }
            i--;
        }
        while (text.getCaretGravity().getAutocomplete() && zInsertionAffectsCaret && (nextAutocomplete = state.autocomplete()) != null) {
            state = nextAutocomplete.getState();
            StringBuilder sb3 = new StringBuilder();
            sb3.append(strDropLast);
            Object insert2 = nextAutocomplete.getInsert();
            if (insert2 == null) {
                insert2 = "";
            }
            sb3.append(insert2);
            strDropLast = sb3.toString();
            StringBuilder sb4 = new StringBuilder();
            sb4.append(strDropLast2);
            Object value2 = nextAutocomplete.getValue();
            if (value2 == null) {
                value2 = "";
            }
            sb4.append(value2);
            strDropLast2 = sb4.toString();
            if (nextAutocomplete.getInsert() != null) {
                caretPosition++;
            }
        }
        while (text.getCaretGravity().getAutoskip() && !autocompletionStack.empty()) {
            Next nextPop = autocompletionStack.pop();
            Intrinsics.checkExpressionValueIsNotNull(nextPop, "autocompletionStack.pop()");
            Next next2 = nextPop;
            if (strDropLast.length() == caretPosition) {
                if (next2.getInsert() != null) {
                    Character insert3 = next2.getInsert();
                    char cLast = StringsKt.last(strDropLast);
                    if (insert3 != null && insert3.charValue() == cLast) {
                        strDropLast = StringsKt.dropLast(strDropLast, 1);
                        caretPosition--;
                    }
                }
                if (next2.getValue() != null) {
                    Character value3 = next2.getValue();
                    char cLast2 = StringsKt.last(strDropLast2);
                    if (value3 != null && value3.charValue() == cLast2) {
                        strDropLast2 = StringsKt.dropLast(strDropLast2, 1);
                    }
                }
            } else if (next2.getInsert() != null) {
                caretPosition--;
            }
        }
        return new Result(new CaretString(strDropLast, caretPosition, text.getCaretGravity()), strDropLast2, i, noMandatoryCharactersLeftAfterState(state));
    }

    public CaretStringIterator makeIterator(CaretString text) {
        Intrinsics.checkParameterIsNotNull(text, "text");
        return new CaretStringIterator(text, 0, 2, null);
    }

    public final String placeholder() {
        return appendPlaceholder(this.initialState, "");
    }

    public final int acceptableTextLength() {
        int i = 0;
        for (State child = this.initialState; child != null && !(child instanceof EOLState); child = child.getChild()) {
            if ((child instanceof FixedState) || (child instanceof FreeState) || (child instanceof ValueState)) {
                i++;
            }
        }
        return i;
    }

    public final int totalTextLength() {
        int i = 0;
        for (State child = this.initialState; child != null && !(child instanceof EOLState); child = child.getChild()) {
            if ((child instanceof FixedState) || (child instanceof FreeState) || (child instanceof ValueState) || (child instanceof OptionalValueState)) {
                i++;
            }
        }
        return i;
    }

    public final int acceptableValueLength() {
        int i = 0;
        for (State child = this.initialState; child != null && !(child instanceof EOLState); child = child.getChild()) {
            if ((child instanceof FixedState) || (child instanceof ValueState)) {
                i++;
            }
        }
        return i;
    }

    public final int totalValueLength() {
        int i = 0;
        for (State child = this.initialState; child != null && !(child instanceof EOLState); child = child.getChild()) {
            if ((child instanceof FixedState) || (child instanceof ValueState) || (child instanceof OptionalValueState)) {
                i++;
            }
        }
        return i;
    }

    private final String appendPlaceholder(State state, String str) {
        if (state == null || (state instanceof EOLState)) {
            return str;
        }
        if (state instanceof FixedState) {
            return appendPlaceholder(state.getChild(), str + ((FixedState) state).getOwnCharacter());
        }
        if (state instanceof FreeState) {
            return appendPlaceholder(state.getChild(), str + ((FreeState) state).getOwnCharacter());
        }
        if (state instanceof OptionalValueState) {
            OptionalValueState optionalValueState = (OptionalValueState) state;
            OptionalValueState.StateType type = optionalValueState.getType();
            if (type instanceof OptionalValueState.StateType.AlphaNumeric) {
                return appendPlaceholder(state.getChild(), str + "-");
            }
            if (type instanceof OptionalValueState.StateType.Literal) {
                return appendPlaceholder(state.getChild(), str + "a");
            }
            if (type instanceof OptionalValueState.StateType.Numeric) {
                return appendPlaceholder(state.getChild(), str + CommonUrlParts.Values.FALSE_INTEGER);
            }
            if (!(type instanceof OptionalValueState.StateType.Custom)) {
                throw new NoWhenBranchMatchedException();
            }
            return appendPlaceholder(state.getChild(), str + ((OptionalValueState.StateType.Custom) optionalValueState.getType()).getCharacter());
        }
        if (state instanceof ValueState) {
            ValueState valueState = (ValueState) state;
            ValueState.StateType type2 = valueState.getType();
            if (type2 instanceof ValueState.StateType.AlphaNumeric) {
                return appendPlaceholder(state.getChild(), str + "-");
            }
            if (type2 instanceof ValueState.StateType.Literal) {
                return appendPlaceholder(state.getChild(), str + "a");
            }
            if (type2 instanceof ValueState.StateType.Numeric) {
                return appendPlaceholder(state.getChild(), str + CommonUrlParts.Values.FALSE_INTEGER);
            }
            if (!(type2 instanceof ValueState.StateType.Ellipsis)) {
                if (!(type2 instanceof ValueState.StateType.Custom)) {
                    throw new NoWhenBranchMatchedException();
                }
                return appendPlaceholder(state.getChild(), str + ((ValueState.StateType.Custom) valueState.getType()).getCharacter());
            }
        }
        return str;
    }

    private final boolean noMandatoryCharactersLeftAfterState(State state) {
        if (state instanceof EOLState) {
            return true;
        }
        if (state instanceof ValueState) {
            return ((ValueState) state).isElliptical();
        }
        if (state instanceof FixedState) {
            return false;
        }
        return noMandatoryCharactersLeftAfterState(state.nextState());
    }

    /* JADX INFO: compiled from: Mask.kt */
    private static final class AutocompletionStack extends Stack<Next> {
        public /* bridge */ boolean contains(Next next) {
            return super.contains((Object) next);
        }

        @Override // java.util.Vector, java.util.AbstractCollection, java.util.Collection, java.util.List
        public final /* bridge */ boolean contains(Object obj) {
            if (obj != null ? obj instanceof Next : true) {
                return contains((Next) obj);
            }
            return false;
        }

        public /* bridge */ int getSize() {
            return super.size();
        }

        public /* bridge */ int indexOf(Next next) {
            return super.indexOf((Object) next);
        }

        @Override // java.util.Vector, java.util.AbstractList, java.util.List
        public final /* bridge */ int indexOf(Object obj) {
            if (obj != null ? obj instanceof Next : true) {
                return indexOf((Next) obj);
            }
            return -1;
        }

        public /* bridge */ int lastIndexOf(Next next) {
            return super.lastIndexOf((Object) next);
        }

        @Override // java.util.Vector, java.util.AbstractList, java.util.List
        public final /* bridge */ int lastIndexOf(Object obj) {
            if (obj != null ? obj instanceof Next : true) {
                return lastIndexOf((Next) obj);
            }
            return -1;
        }

        @Override // java.util.Vector, java.util.AbstractList, java.util.List
        public final /* bridge */ Next remove(int i) {
            return removeAt(i);
        }

        public /* bridge */ boolean remove(Next next) {
            return super.remove((Object) next);
        }

        @Override // java.util.Vector, java.util.AbstractCollection, java.util.Collection, java.util.List
        public final /* bridge */ boolean remove(Object obj) {
            if (obj != null ? obj instanceof Next : true) {
                return remove((Next) obj);
            }
            return false;
        }

        public /* bridge */ Next removeAt(int i) {
            return (Next) super.remove(i);
        }

        @Override // java.util.Vector, java.util.AbstractCollection, java.util.Collection, java.util.List
        public final /* bridge */ int size() {
            return getSize();
        }

        @Override // java.util.Stack
        public Next push(Next next) {
            if (next != null) {
                return (Next) super.push(next);
            }
            removeAllElements();
            return null;
        }
    }
}
