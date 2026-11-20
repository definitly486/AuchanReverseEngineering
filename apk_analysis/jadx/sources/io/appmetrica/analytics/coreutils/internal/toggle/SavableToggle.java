package io.appmetrica.analytics.coreutils.internal.toggle;

import io.appmetrica.analytics.coreapi.internal.data.Savable;
import io.appmetrica.analytics.coreapi.internal.data.Updatable;

/* JADX INFO: loaded from: classes3.dex */
public final class SavableToggle extends SimpleThreadSafeToggle implements Updatable<Boolean> {
    private final Savable d;

    public SavableToggle(String str, Savable<Boolean> savable) {
        super(savable.getValue().booleanValue(), "[SavableToggle - " + str + ']');
        this.d = savable;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Updatable
    public /* bridge */ /* synthetic */ void update(Boolean bool) {
        update(bool.booleanValue());
    }

    public void update(boolean z) {
        updateState(z);
        this.d.setValue(Boolean.valueOf(getActualState()));
    }
}
