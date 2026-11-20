package io.appmetrica.analytics.screenshot.impl;

import com.scanflow.datacapture.barinternal.kotlin.TuplesKt;
import com.scanflow.datacapture.barinternal.kotlin.collections.MapsKt;
import io.appmetrica.analytics.modulesapi.internal.client.ClientContext;
import io.appmetrica.analytics.modulesapi.internal.common.InternalModuleEvent;

/* JADX INFO: renamed from: io.appmetrica.analytics.screenshot.impl.x, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0809x implements Q {
    public final ClientContext a;

    public C0809x(ClientContext clientContext) {
        this.a = clientContext;
    }

    public final void a(String str) {
        this.a.getInternalClientModuleFacade().reportEvent(InternalModuleEvent.Companion.newBuilder(4).withName("appmetrica_system_event_screenshot").withAttributes(MapsKt.mapOf(TuplesKt.to("type", str))).withCategory(InternalModuleEvent.Category.SYSTEM).build());
    }
}
