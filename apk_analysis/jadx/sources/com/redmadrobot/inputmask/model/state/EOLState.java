package com.redmadrobot.inputmask.model.state;

import com.redmadrobot.inputmask.model.Next;
import com.redmadrobot.inputmask.model.State;

/* JADX INFO: compiled from: EOLState.kt */
/* JADX INFO: loaded from: classes3.dex */
public final class EOLState extends State {
    @Override // com.redmadrobot.inputmask.model.State
    public Next accept(char c) {
        return null;
    }

    public EOLState() {
        super(null);
    }

    @Override // com.redmadrobot.inputmask.model.State
    public String toString() {
        return "EOL";
    }
}
