package io.appmetrica.analytics.screenshot.impl;

import io.appmetrica.analytics.screenshot.internal.config.RemoteScreenshotConfig;

/* JADX INFO: loaded from: classes3.dex */
public final class g0 {
    public final boolean a;
    public final h0 b;

    public g0(boolean z, h0 h0Var) {
        this.a = z;
        this.b = h0Var;
    }

    public final h0 a() {
        return this.b;
    }

    public final boolean b() {
        return this.a;
    }

    public final String toString() {
        return "ServiceSideRemoteScreenshotConfig(enabled=" + this.a + ", config=" + this.b + ')';
    }

    public g0() {
        this(new RemoteScreenshotConfig());
    }

    /* JADX WARN: Illegal instructions before constructor call */
    public g0(RemoteScreenshotConfig remoteScreenshotConfig) {
        boolean enabled = remoteScreenshotConfig.getEnabled();
        T config$screenshot_release = remoteScreenshotConfig.getConfig$screenshot_release();
        this(enabled, config$screenshot_release != null ? new h0(config$screenshot_release) : null);
    }
}
