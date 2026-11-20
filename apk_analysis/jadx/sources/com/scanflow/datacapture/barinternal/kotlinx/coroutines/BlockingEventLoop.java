package com.scanflow.datacapture.barinternal.kotlinx.coroutines;

/* JADX INFO: compiled from: EventLoop.kt */
/* JADX INFO: loaded from: classes3.dex */
public final class BlockingEventLoop extends EventLoopImplBase {
    private final Thread thread;

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.EventLoopImplPlatform
    protected Thread getThread() {
        return this.thread;
    }

    public BlockingEventLoop(Thread thread) {
        this.thread = thread;
    }
}
