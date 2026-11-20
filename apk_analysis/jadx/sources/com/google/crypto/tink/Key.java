package com.google.crypto.tink;

import com.google.errorprone.annotations.Immutable;

/* JADX INFO: loaded from: classes2.dex */
@Immutable
public abstract class Key {
    public abstract boolean equalsKey(Key key);

    public abstract Integer getIdRequirementOrNull();

    public abstract Parameters getParameters();
}
