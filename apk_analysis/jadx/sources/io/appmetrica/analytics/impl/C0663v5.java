package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.collections.ArraysKt;
import io.appmetrica.analytics.coreapi.internal.io.IExecutionPolicy;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.v5, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0663v5 implements IExecutionPolicy {
    public final IExecutionPolicy[] a;
    public final String b;

    public C0663v5(IExecutionPolicy... iExecutionPolicyArr) {
        this.a = iExecutionPolicyArr;
        this.b = "Composite of {" + ArraysKt.joinToString$default(iExecutionPolicyArr, ", ", null, null, 0, null, C0637u5.a, 30, null) + '}';
    }

    /* JADX WARN: Code duplicated, block: B:13:0x001a A[RETURN] */
    /* JADX WARN: Code duplicated, block: B:14:0x001b A[RETURN] */
    @Override // io.appmetrica.analytics.coreapi.internal.io.IExecutionPolicy
    public final boolean canBeExecuted() {
        IExecutionPolicy[] iExecutionPolicyArr = this.a;
        if (iExecutionPolicyArr.length == 0) {
            return false;
        }
        for (IExecutionPolicy iExecutionPolicy : iExecutionPolicyArr) {
            if (!iExecutionPolicy.canBeExecuted()) {
                if (iExecutionPolicy != null) {
                    return false;
                }
                return true;
            }
        }
        iExecutionPolicy = null;
        if (iExecutionPolicy != null) {
            return false;
        }
        return true;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.io.IExecutionPolicy
    public final String description() {
        return this.b;
    }
}
