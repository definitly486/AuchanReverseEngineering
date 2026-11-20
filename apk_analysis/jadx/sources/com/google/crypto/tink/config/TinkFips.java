package com.google.crypto.tink.config;

import com.google.crypto.tink.Registry;
import com.google.crypto.tink.config.internal.TinkFipsUtil;

/* JADX INFO: loaded from: classes2.dex */
public final class TinkFips {
    public static boolean useOnlyFips() {
        return TinkFipsUtil.useOnlyFips();
    }

    public static void restrictToFips() {
        Registry.restrictToFipsIfEmpty();
    }

    private TinkFips() {
    }
}
