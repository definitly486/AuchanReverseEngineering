package com.redmadrobot.inputmask.model;

import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: State.kt */
/* JADX INFO: loaded from: classes3.dex */
public abstract class State {
    private final State child;

    public abstract Next accept(char c);

    public Next autocomplete() {
        return null;
    }

    public State(State state) {
        this.child = state;
    }

    public final State getChild() {
        return this.child;
    }

    public State nextState() {
        State state = this.child;
        if (state == null) {
            Intrinsics.throwNpe();
        }
        return state;
    }

    public String toString() {
        StringBuilder sb = new StringBuilder();
        sb.append("BASE -> ");
        State state = this.child;
        sb.append(state != null ? state.toString() : "null");
        return sb.toString();
    }
}
