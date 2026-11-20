package io.appmetrica.analytics.coreapi.internal.servicecomponents.applicationstate;

/* JADX INFO: loaded from: classes3.dex */
public interface ApplicationStateProvider {
    ApplicationState getCurrentState();

    ApplicationState registerStickyObserver(ApplicationStateObserver applicationStateObserver);
}
