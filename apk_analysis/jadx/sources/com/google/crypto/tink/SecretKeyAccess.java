package com.google.crypto.tink;

import com.google.errorprone.annotations.CanIgnoreReturnValue;
import com.google.errorprone.annotations.CheckReturnValue;
import com.google.errorprone.annotations.Immutable;
import java.security.GeneralSecurityException;

/* JADX INFO: loaded from: classes2.dex */
@Immutable
@CheckReturnValue
public final class SecretKeyAccess {
    private static final SecretKeyAccess INSTANCE = new SecretKeyAccess();

    private SecretKeyAccess() {
    }

    static SecretKeyAccess instance() {
        return INSTANCE;
    }

    @CanIgnoreReturnValue
    public static SecretKeyAccess requireAccess(SecretKeyAccess secretKeyAccess) throws GeneralSecurityException {
        if (secretKeyAccess != null) {
            return secretKeyAccess;
        }
        throw new GeneralSecurityException("SecretKeyAccess is required");
    }
}
