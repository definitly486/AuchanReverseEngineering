package com.scanflow.datacapture.barinternal.kotlin.random;

import com.scanflow.datacapture.barinternal.kotlin.internal.PlatformImplementationsKt;
import java.io.Serializable;
import kotlin.jvm.internal.DefaultConstructorMarker;

/* JADX INFO: compiled from: Random.kt */
/* JADX INFO: loaded from: classes3.dex */
public abstract class Random {
    public static final Default Default = new Default(null);
    private static final Random defaultRandom = PlatformImplementationsKt.IMPLEMENTATIONS.defaultPlatformRandom();

    public abstract int nextInt(int i);

    /* JADX INFO: compiled from: Random.kt */
    public static final class Default extends Random implements Serializable {
        public /* synthetic */ Default(DefaultConstructorMarker defaultConstructorMarker) {
            this();
        }

        private Default() {
        }

        @Override // com.scanflow.datacapture.barinternal.kotlin.random.Random
        public int nextInt(int i) {
            return Random.defaultRandom.nextInt(i);
        }
    }
}
