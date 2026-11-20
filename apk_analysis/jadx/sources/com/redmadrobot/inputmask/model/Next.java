package com.redmadrobot.inputmask.model;

import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: Next.kt */
/* JADX INFO: loaded from: classes3.dex */
public final class Next {
    private final Character insert;
    private final boolean pass;
    private final State state;
    private final Character value;

    public Next(State state, Character ch, boolean z, Character ch2) {
        Intrinsics.checkParameterIsNotNull(state, "state");
        this.state = state;
        this.insert = ch;
        this.pass = z;
        this.value = ch2;
    }

    public final Character getInsert() {
        return this.insert;
    }

    public final boolean getPass() {
        return this.pass;
    }

    public final State getState() {
        return this.state;
    }

    public final Character getValue() {
        return this.value;
    }
}
