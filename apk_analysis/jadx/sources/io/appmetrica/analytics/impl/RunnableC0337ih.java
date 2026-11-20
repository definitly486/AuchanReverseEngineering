package io.appmetrica.analytics.impl;

import com.google.mediapipe.framework.AssetCacheDbHelper;
import com.scanflow.datacapture.barinternal.kotlin.Pair;
import com.scanflow.datacapture.barinternal.kotlin.TuplesKt;
import com.scanflow.datacapture.barinternal.kotlin.collections.MapsKt;
import io.appmetrica.analytics.coreutils.internal.time.SystemTimeProvider;
import io.appmetrica.analytics.coreutils.internal.time.TimePassedChecker;
import java.util.Map;
import java.util.concurrent.TimeUnit;
import kotlin.KotlinVersion;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.ih, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class RunnableC0337ih implements Runnable {
    @Override // java.lang.Runnable
    public final void run() {
        TimePassedChecker timePassedChecker = new TimePassedChecker();
        SystemTimeProvider systemTimeProvider = new SystemTimeProvider();
        C0621tf c0621tfY = Ka.I.y();
        if (timePassedChecker.didTimePassMillis(c0621tfY.f(), TimeUnit.DAYS.toMillis(1L), "[ReportKotlinVersionTask]")) {
            KotlinVersion kotlinVersion = KotlinVersion.CURRENT;
            Pair pair = TuplesKt.to("major", Integer.valueOf(kotlinVersion.getMajor()));
            Pair pair2 = TuplesKt.to("minor", Integer.valueOf(kotlinVersion.getMinor()));
            Pair pair3 = TuplesKt.to("patch", Integer.valueOf(kotlinVersion.getPatch()));
            StringBuilder sb = new StringBuilder();
            sb.append(kotlinVersion.getMajor());
            sb.append('.');
            sb.append(kotlinVersion.getMinor());
            sb.append('.');
            sb.append(kotlinVersion.getPatch());
            Map mapMapOf = MapsKt.mapOf(pair, pair2, pair3, TuplesKt.to(AssetCacheDbHelper.AssetCacheEntry.COLUMN_NAME_VERSION, sb.toString()));
            C0263fk c0263fk = Dj.a;
            c0263fk.getClass();
            c0263fk.a(new C0237ek("kotlin_version", mapMapOf));
            c0621tfY.a(systemTimeProvider.currentTimeMillis());
        }
    }
}
