package com.scanflow.datacapture.barinternal.org.ddogleg.struct;

import java.io.Serializable;

/* JADX INFO: loaded from: classes3.dex */
public interface DProcess {
    void process(Object obj);

    public static class DoNothing implements DProcess, Serializable {
        @Override // com.scanflow.datacapture.barinternal.org.ddogleg.struct.DProcess
        public void process(Object obj) {
        }
    }
}
