package io.appmetrica.analytics.impl;

import android.content.Context;
import io.appmetrica.analytics.ReporterConfig;
import io.appmetrica.analytics.coreutils.internal.logger.LoggerStorage;
import io.appmetrica.analytics.internal.CounterConfiguration;

/* JADX INFO: loaded from: classes3.dex */
public final class Tc extends V2 {
    public Tc(Context context, Wf wf, ReporterConfig reporterConfig, Ji ji, C0305ha c0305ha) {
        this(context, ji, new Sh(wf, new CounterConfiguration(reporterConfig), new W8(new Ll(LoggerStorage.getOrCreatePublicLogger(reporterConfig.apiKey), "Crash Environment")), reporterConfig.userProfileID), c0305ha, C0584s4.l().n(), new C0370jo(), new Ng(), new N6(), new C0243f0(), new C0232ef(c0305ha));
    }

    @Override // io.appmetrica.analytics.impl.V2
    public final String j() {
        return "[ManualReporter]";
    }

    public Tc(Context context, Ji ji, Sh sh, C0305ha c0305ha, J6 j6, C0370jo c0370jo, Ng ng, N6 n6, C0243f0 c0243f0, C0232ef c0232ef) {
        super(context, ji, sh, c0305ha, j6, c0370jo, ng, n6, c0243f0, c0232ef);
        C0584s4.l().getClass();
    }
}
