package com.google.crypto.tink.daead;

import com.google.crypto.tink.config.TinkFips;
import com.google.crypto.tink.proto.RegistryConfig;
import com.google.errorprone.annotations.CanIgnoreReturnValue;
import com.google.errorprone.annotations.InlineMe;
import java.security.GeneralSecurityException;

/* JADX INFO: loaded from: classes2.dex */
public final class DeterministicAeadConfig {
    public static final String AES_SIV_TYPE_URL = initializeClassReturnInput("type.googleapis.com/google.crypto.tink.AesSivKey");

    @Deprecated
    public static final RegistryConfig TINK_1_1_0 = RegistryConfig.getDefaultInstance();

    @Deprecated
    public static final RegistryConfig LATEST = RegistryConfig.getDefaultInstance();

    @CanIgnoreReturnValue
    private static String initializeClassReturnInput(String str) {
        return str;
    }

    static {
        try {
            register();
        } catch (GeneralSecurityException e) {
            throw new ExceptionInInitializerError(e);
        }
    }

    @InlineMe(imports = {"com.google.crypto.tink.daead.DeterministicAeadConfig"}, replacement = "DeterministicAeadConfig.register()")
    @Deprecated
    public static void init() {
        register();
    }

    public static void register() {
        DeterministicAeadWrapper.register();
        if (TinkFips.useOnlyFips()) {
            return;
        }
        AesSivKeyManager.register(true);
    }

    private DeterministicAeadConfig() {
    }
}
