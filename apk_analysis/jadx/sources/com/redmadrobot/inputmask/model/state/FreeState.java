package com.redmadrobot.inputmask.model.state;

import com.redmadrobot.inputmask.model.Next;
import com.redmadrobot.inputmask.model.State;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: FreeState.kt */
/* JADX INFO: loaded from: classes3.dex */
public final class FreeState extends State {
    private final char ownCharacter;

    /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
    public FreeState(State child, char c) {
        super(child);
        Intrinsics.checkParameterIsNotNull(child, "child");
        this.ownCharacter = c;
    }

    public final char getOwnCharacter() {
        return this.ownCharacter;
    }

    @Override // com.redmadrobot.inputmask.model.State
    public Next accept(char c) {
        if (this.ownCharacter == c) {
            return new Next(nextState(), Character.valueOf(c), true, null);
        }
        return new Next(nextState(), Character.valueOf(this.ownCharacter), false, null);
    }

    @Override // com.redmadrobot.inputmask.model.State
    public Next autocomplete() {
        return new Next(nextState(), Character.valueOf(this.ownCharacter), false, null);
    }

    @Override // com.redmadrobot.inputmask.model.State
    public String toString() {
        StringBuilder sb = new StringBuilder();
        sb.append("");
        sb.append(this.ownCharacter);
        sb.append(" -> ");
        sb.append(getChild() == null ? "null" : getChild().toString());
        return sb.toString();
    }
}
