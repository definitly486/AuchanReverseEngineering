package io.appmetrica.analytics.screenshot.impl;

import io.appmetrica.analytics.coreapi.internal.data.Converter;
import io.appmetrica.analytics.screenshot.internal.config.RemoteScreenshotConfig;
import kotlin.jvm.internal.DefaultConstructorMarker;

/* JADX INFO: loaded from: classes3.dex */
public final class J implements Converter {
    public final V a;

    /* JADX WARN: Multi-variable type inference failed */
    public J() {
        this(null, 1, 0 == true ? 1 : 0);
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final O fromModel(RemoteScreenshotConfig remoteScreenshotConfig) {
        O o = new O();
        o.a = remoteScreenshotConfig.getEnabled();
        T config$screenshot_release = remoteScreenshotConfig.getConfig$screenshot_release();
        o.b = config$screenshot_release != null ? this.a.fromModel(config$screenshot_release) : null;
        return o;
    }

    public J(V v) {
        this.a = v;
    }

    public /* synthetic */ J(V v, int i, DefaultConstructorMarker defaultConstructorMarker) {
        if ((i & 1) != 0) {
            v = new V(null, null, null, 7, null);
        }
        this(v);
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final RemoteScreenshotConfig toModel(O o) {
        return new RemoteScreenshotConfig(o.a, this.a.toModel(o.b));
    }
}
