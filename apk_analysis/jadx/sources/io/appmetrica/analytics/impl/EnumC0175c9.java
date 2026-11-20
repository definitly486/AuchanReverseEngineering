package io.appmetrica.analytics.impl;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.c9, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public enum EnumC0175c9 {
    NONE(0),
    EXTERNALLY_ENCRYPTED_EVENT_CRYPTER(1),
    AES_VALUE_ENCRYPTION(2);

    public final int a;

    EnumC0175c9(int i) {
        this.a = i;
    }

    public static EnumC0175c9 a(Integer num) {
        if (num != null) {
            for (EnumC0175c9 enumC0175c9 : values()) {
                if (enumC0175c9.a == num.intValue()) {
                    return enumC0175c9;
                }
            }
        }
        return NONE;
    }
}
