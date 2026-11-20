package com.redmadrobot.inputmask.model;

import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: Notation.kt */
/* JADX INFO: loaded from: classes3.dex */
public final class Notation {
    private final char character;
    private final String characterSet;
    private final boolean isOptional;

    public static /* synthetic */ Notation copy$default(Notation notation, char c, String str, boolean z, int i, Object obj) {
        if ((i & 1) != 0) {
            c = notation.character;
        }
        if ((i & 2) != 0) {
            str = notation.characterSet;
        }
        if ((i & 4) != 0) {
            z = notation.isOptional;
        }
        return notation.copy(c, str, z);
    }

    public final char component1() {
        return this.character;
    }

    public final String component2() {
        return this.characterSet;
    }

    public final boolean component3() {
        return this.isOptional;
    }

    public final Notation copy(char c, String characterSet, boolean z) {
        Intrinsics.checkParameterIsNotNull(characterSet, "characterSet");
        return new Notation(c, characterSet, z);
    }

    public boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (!(obj instanceof Notation)) {
            return false;
        }
        Notation notation = (Notation) obj;
        return this.character == notation.character && Intrinsics.areEqual(this.characterSet, notation.characterSet) && this.isOptional == notation.isOptional;
    }

    /* JADX WARN: Multi-variable type inference failed */
    /* JADX WARN: Type inference failed for: r0v4, types: [int] */
    /* JADX WARN: Type inference failed for: r1v4, types: [int] */
    /* JADX WARN: Type inference failed for: r1v5 */
    /* JADX WARN: Type inference failed for: r1v7 */
    public int hashCode() {
        int i = this.character * 31;
        String str = this.characterSet;
        int iHashCode = (i + (str != null ? str.hashCode() : 0)) * 31;
        boolean z = this.isOptional;
        ?? r1 = z;
        if (z) {
            r1 = 1;
        }
        return iHashCode + r1;
    }

    public String toString() {
        return "Notation(character=" + this.character + ", characterSet=" + this.characterSet + ", isOptional=" + this.isOptional + ")";
    }

    public Notation(char c, String characterSet, boolean z) {
        Intrinsics.checkParameterIsNotNull(characterSet, "characterSet");
        this.character = c;
        this.characterSet = characterSet;
        this.isOptional = z;
    }

    public final char getCharacter() {
        return this.character;
    }

    public final String getCharacterSet() {
        return this.characterSet;
    }

    public final boolean isOptional() {
        return this.isOptional;
    }
}
