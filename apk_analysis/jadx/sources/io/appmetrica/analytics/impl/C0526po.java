package io.appmetrica.analytics.impl;

import android.content.Context;
import android.os.UserManager;
import io.appmetrica.analytics.coreapi.internal.backport.FunctionWithThrowable;
import io.appmetrica.analytics.coreutils.internal.system.SystemServiceUtils;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.po, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0526po {
    public static boolean a(Context context) {
        Boolean bool = (Boolean) SystemServiceUtils.accessSystemServiceSafelyOrDefault((UserManager) context.getSystemService(UserManager.class), "detect unlocked user state", "User manager", Boolean.TRUE, new FunctionWithThrowable() { // from class: io.appmetrica.analytics.impl.po$$ExternalSyntheticLambda0
            @Override // io.appmetrica.analytics.coreapi.internal.backport.FunctionWithThrowable
            public final Object apply(Object obj) {
                return C0526po.a((UserManager) obj);
            }
        });
        if (bool != null) {
            return bool.booleanValue();
        }
        return true;
    }

    public static final Boolean a(UserManager userManager) {
        return Boolean.valueOf(userManager.isUserUnlocked());
    }
}
