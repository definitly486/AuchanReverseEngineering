package com.scanflow.datacapture.barinternal.kotlinx.coroutines.channels;

import com.scanflow.datacapture.barinternal.kotlin.ExceptionsKt;
import com.scanflow.datacapture.barinternal.kotlin.Unit;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.internal.OnUndeliveredElementKt;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.internal.UndeliveredElementException;
import kotlin.coroutines.Continuation;
import kotlin.jvm.functions.Function1;
import kotlin.jvm.internal.Reflection;

/* JADX INFO: compiled from: ConflatedBufferedChannel.kt */
/* JADX INFO: loaded from: classes3.dex */
public class ConflatedBufferedChannel extends BufferedChannel {
    private final int capacity;
    private final BufferOverflow onBufferOverflow;

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.channels.BufferedChannel, com.scanflow.datacapture.barinternal.kotlinx.coroutines.channels.SendChannel
    public Object send(Object obj, Continuation continuation) {
        return send$suspendImpl(this, obj, continuation);
    }

    public ConflatedBufferedChannel(int i, BufferOverflow bufferOverflow, Function1 function1) {
        super(i, function1);
        this.capacity = i;
        this.onBufferOverflow = bufferOverflow;
        if (bufferOverflow == BufferOverflow.SUSPEND) {
            throw new IllegalArgumentException(("This implementation does not support suspension for senders, use " + Reflection.getOrCreateKotlinClass(BufferedChannel.class).getSimpleName() + " instead").toString());
        }
        if (i >= 1) {
            return;
        }
        throw new IllegalArgumentException(("Buffered channel capacity must be at least 1, but " + i + " was specified").toString());
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.channels.BufferedChannel
    protected boolean isConflatedDropOldest() {
        return this.onBufferOverflow == BufferOverflow.DROP_OLDEST;
    }

    static /* synthetic */ Object send$suspendImpl(ConflatedBufferedChannel conflatedBufferedChannel, Object obj, Continuation continuation) throws Throwable {
        UndeliveredElementException undeliveredElementExceptionCallUndeliveredElementCatchingException$default;
        Object objM856trySendImplMj0NB7M = conflatedBufferedChannel.m856trySendImplMj0NB7M(obj, true);
        if (objM856trySendImplMj0NB7M instanceof ChannelResult.Closed) {
            ChannelResult.m845exceptionOrNullimpl(objM856trySendImplMj0NB7M);
            Function1 function1 = conflatedBufferedChannel.onUndeliveredElement;
            if (function1 != null && (undeliveredElementExceptionCallUndeliveredElementCatchingException$default = OnUndeliveredElementKt.callUndeliveredElementCatchingException$default(function1, obj, null, 2, null)) != null) {
                ExceptionsKt.addSuppressed(undeliveredElementExceptionCallUndeliveredElementCatchingException$default, conflatedBufferedChannel.getSendException());
                throw undeliveredElementExceptionCallUndeliveredElementCatchingException$default;
            }
            throw conflatedBufferedChannel.getSendException();
        }
        return Unit.INSTANCE;
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.channels.BufferedChannel, com.scanflow.datacapture.barinternal.kotlinx.coroutines.channels.SendChannel
    /* JADX INFO: renamed from: trySend-JP2dKIU */
    public Object mo839trySendJP2dKIU(Object obj) {
        return m856trySendImplMj0NB7M(obj, false);
    }

    /* JADX INFO: renamed from: trySendImpl-Mj0NB7M, reason: not valid java name */
    private final Object m856trySendImplMj0NB7M(Object obj, boolean z) {
        return this.onBufferOverflow == BufferOverflow.DROP_LATEST ? m855trySendDropLatestMj0NB7M(obj, z) : m840trySendDropOldestJP2dKIU(obj);
    }

    /* JADX INFO: renamed from: trySendDropLatest-Mj0NB7M, reason: not valid java name */
    private final Object m855trySendDropLatestMj0NB7M(Object obj, boolean z) {
        Function1 function1;
        UndeliveredElementException undeliveredElementExceptionCallUndeliveredElementCatchingException$default;
        Object objMo839trySendJP2dKIU = super.mo839trySendJP2dKIU(obj);
        if (ChannelResult.m849isSuccessimpl(objMo839trySendJP2dKIU) || ChannelResult.m848isClosedimpl(objMo839trySendJP2dKIU)) {
            return objMo839trySendJP2dKIU;
        }
        if (z && (function1 = this.onUndeliveredElement) != null && (undeliveredElementExceptionCallUndeliveredElementCatchingException$default = OnUndeliveredElementKt.callUndeliveredElementCatchingException$default(function1, obj, null, 2, null)) != null) {
            throw undeliveredElementExceptionCallUndeliveredElementCatchingException$default;
        }
        return ChannelResult.Companion.m854successJP2dKIU(Unit.INSTANCE);
    }
}
