package com.scanflow.datacapture.barinternal.kotlin.uuid;

import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: UuidJVM.kt */
/* JADX INFO: loaded from: classes3.dex */
abstract class UuidKt__UuidJVMKt {
    public static final void formatBytesInto(long j, byte[] dst, int i, int i2, int i3) {
        Intrinsics.checkNotNullParameter(dst, "dst");
        UuidKt__UuidKt.formatBytesIntoCommonImpl(j, dst, i, i2, i3);
    }

    public static final Uuid uuidParseHexDash(String hexDashString) {
        Intrinsics.checkNotNullParameter(hexDashString, "hexDashString");
        return UuidKt__UuidKt.uuidParseHexDashCommonImpl(hexDashString);
    }

    public static final Uuid uuidParseHex(String hexString) {
        Intrinsics.checkNotNullParameter(hexString, "hexString");
        return UuidKt__UuidKt.uuidParseHexCommonImpl(hexString);
    }
}
