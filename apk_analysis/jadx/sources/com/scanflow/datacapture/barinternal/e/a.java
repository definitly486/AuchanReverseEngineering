package com.scanflow.datacapture.barinternal.e;

import android.content.Context;
import android.hardware.Sensor;
import android.hardware.SensorEvent;
import android.hardware.SensorEventListener;
import android.hardware.SensorManager;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public final class a implements SensorEventListener {
    public final SensorManager a;
    public final Sensor b;
    public long c;
    public boolean d;
    public InterfaceC0036a e;

    /* JADX INFO: renamed from: com.scanflow.datacapture.barinternal.e.a$a, reason: collision with other inner class name */
    public interface InterfaceC0036a {
        void a(boolean z);
    }

    public a(Context context) {
        Intrinsics.checkNotNullParameter(context, "context");
        Object systemService = context.getSystemService("sensor");
        Intrinsics.checkNotNull(systemService, "null cannot be cast to non-null type android.hardware.SensorManager");
        SensorManager sensorManager = (SensorManager) systemService;
        this.a = sensorManager;
        this.b = sensorManager.getDefaultSensor(5);
        this.d = true;
    }

    public final void a() {
        Sensor sensor;
        SensorManager sensorManager = this.a;
        if (sensorManager == null || (sensor = this.b) == null) {
            return;
        }
        sensorManager.registerListener(this, sensor, 3);
    }

    public final void b() {
        SensorManager sensorManager = this.a;
        if (sensorManager == null || this.b == null) {
            return;
        }
        sensorManager.unregisterListener(this);
    }

    @Override // android.hardware.SensorEventListener
    public final void onAccuracyChanged(Sensor sensor, int i) {
        Intrinsics.checkNotNullParameter(sensor, "sensor");
    }

    @Override // android.hardware.SensorEventListener
    public final void onSensorChanged(SensorEvent sensorEvent) {
        Intrinsics.checkNotNullParameter(sensorEvent, "sensorEvent");
        if (this.d) {
            long jCurrentTimeMillis = System.currentTimeMillis();
            if (jCurrentTimeMillis - this.c < 200) {
                return;
            }
            this.c = jCurrentTimeMillis;
            InterfaceC0036a interfaceC0036a = this.e;
            if (interfaceC0036a != null) {
                float f = sensorEvent.values[0];
                Intrinsics.checkNotNull(interfaceC0036a);
                if (f <= 4.0f) {
                    interfaceC0036a.a(true);
                } else {
                    interfaceC0036a.a(false);
                }
            }
        }
    }
}
