package io.appmetrica.analytics.logger.appmetrica.internal;

import android.content.Context;
import io.appmetrica.analytics.logger.common.BaseReleaseLogger;
import kotlin.jvm.internal.DefaultConstructorMarker;

/* JADX INFO: loaded from: classes3.dex */
public final class PublicLogger extends BaseReleaseLogger {
    public static final Companion Companion = new Companion(null);
    private static final PublicLogger a = new PublicLogger("");

    public static final class Companion {
        public /* synthetic */ Companion(DefaultConstructorMarker defaultConstructorMarker) {
            this();
        }

        public final PublicLogger getAnonymousInstance() {
            return PublicLogger.a;
        }

        public final void init(Context context) {
            BaseReleaseLogger.init(context);
        }

        private Companion() {
        }
    }

    public PublicLogger(String str) {
        super("AppMetrica", "[" + str + ']');
    }

    public static final PublicLogger getAnonymousInstance() {
        return Companion.getAnonymousInstance();
    }
}
