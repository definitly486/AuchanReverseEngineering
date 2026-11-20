package com.google.common.flogger.backend;

import com.google.common.flogger.backend.system.DefaultPlatform;
import java.lang.reflect.InvocationTargetException;

/* JADX INFO: loaded from: classes2.dex */
public final class PlatformProvider {
    private PlatformProvider() {
    }

    public static Platform getPlatform() {
        try {
            return (Platform) DefaultPlatform.class.getDeclaredConstructor(null).newInstance(null);
        } catch (IllegalAccessException | InstantiationException | NoClassDefFoundError | NoSuchMethodException | InvocationTargetException unused) {
            return null;
        }
    }
}
