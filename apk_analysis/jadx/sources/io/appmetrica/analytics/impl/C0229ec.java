package io.appmetrica.analytics.impl;

import android.content.res.Configuration;
import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import io.appmetrica.analytics.coreutils.internal.AndroidUtils;
import java.util.List;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.ec, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0229ec {
    public static List a(Configuration configuration) {
        return AndroidUtils.isApiAchieved(24) ? AbstractC0255fc.a(configuration) : CollectionsKt.listOf(AbstractC0155bf.a(configuration.locale));
    }
}
