package com.redmadrobot.inputmask.model.state;

import com.redmadrobot.inputmask.model.Next;
import com.redmadrobot.inputmask.model.State;

/* JADX INFO: compiled from: FixedState.kt */
/* JADX INFO: loaded from: classes3.dex */
public final class FixedState extends State {
    private final char ownCharacter;

    public FixedState(State state, char c) {
        super(state);
        this.ownCharacter = c;
    }

    public final char getOwnCharacter() {
        return this.ownCharacter;
    }

    @Override // com.redmadrobot.inputmask.model.State
    public Next accept(char c) {
        if (this.ownCharacter == c) {
            return new Next(nextState(), Character.valueOf(c), true, Character.valueOf(c));
        }
        return new Next(nextState(), Character.valueOf(this.ownCharacter), false, Character.valueOf(this.ownCharacter));
    }

    @Override // com.redmadrobot.inputmask.model.State
    public Next autocomplete() {
        return new Next(nextState(), Character.valueOf(this.ownCharacter), false, Character.valueOf(this.ownCharacter));
    }

    @Override // com.redmadrobot.inputmask.model.State
    public String toString() {
        StringBuilder sb = new StringBuilder();
        sb.append("{");
        sb.append(this.ownCharacter);
        sb.append("} -> ");
        sb.append(getChild() == null ? "null" : getChild().toString());
        return sb.toString();
    }
}
