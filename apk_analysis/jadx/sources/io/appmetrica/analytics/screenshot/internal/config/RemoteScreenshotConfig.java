package io.appmetrica.analytics.screenshot.internal.config;

import io.appmetrica.analytics.screenshot.impl.O;
import io.appmetrica.analytics.screenshot.impl.T;

/* JADX INFO: loaded from: classes3.dex */
public final class RemoteScreenshotConfig {
    private final boolean a;
    private final T b;

    public RemoteScreenshotConfig(boolean z, T t) {
        this.a = z;
        this.b = t;
    }

    public final T getConfig$screenshot_release() {
        return this.b;
    }

    public final boolean getEnabled() {
        return this.a;
    }

    public String toString() {
        return "RemoteScreenshotConfig(enabled=" + this.a + ", config=" + this.b + ')';
    }

    public RemoteScreenshotConfig() {
        this(new O().a, new T());
    }
}
