package com.scanflow.datacapture.barinternal;

/* JADX INFO: renamed from: com.scanflow.datacapture.barinternal.d, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0086d {
    public final String a;
    public final String b;
    public final Float c;

    public C0086d(String str, String str2, Float f) {
        this.a = str;
        this.b = str2;
        this.c = f;
    }

    public final String toString() {
        String str;
        if (this.a != null) {
            str = "[" + this.a + "] ";
        } else {
            str = "";
        }
        if (this.b != null) {
            str = str + this.b + " ";
        }
        if (this.c != null) {
            str = str + String.format("(%.1f%%) ", Float.valueOf(this.c.floatValue() * 100.0f));
        }
        return str.trim();
    }
}
