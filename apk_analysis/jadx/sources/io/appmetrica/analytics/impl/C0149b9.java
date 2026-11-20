package io.appmetrica.analytics.impl;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.b9, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0149b9 {
    public final Yc a;
    public final Yc b;

    public C0149b9() {
        this(new C0484o8(), new C0279ga(), new C0139b());
    }

    public C0149b9(C0484o8 c0484o8, C0279ga c0279ga, C0139b c0139b) {
        Yc yc = new Yc(c0484o8);
        this.a = yc;
        yc.a(EnumC0175c9.NONE, c0484o8);
        yc.a(EnumC0175c9.EXTERNALLY_ENCRYPTED_EVENT_CRYPTER, c0279ga);
        yc.a(EnumC0175c9.AES_VALUE_ENCRYPTION, c0139b);
        this.b = new Yc(c0484o8);
    }
}
