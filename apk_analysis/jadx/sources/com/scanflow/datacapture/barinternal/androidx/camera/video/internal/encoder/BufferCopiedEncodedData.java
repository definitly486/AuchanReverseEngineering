package com.scanflow.datacapture.barinternal.androidx.camera.video.internal.encoder;

import android.media.MediaCodec;
import androidx.concurrent.futures.CallbackToFutureAdapter;
import com.google.common.util.concurrent.ListenableFuture;
import com.scanflow.datacapture.barinternal.androidx.core.util.Preconditions;
import java.nio.ByteBuffer;
import java.util.concurrent.atomic.AtomicReference;

/* JADX INFO: loaded from: classes.dex */
public class BufferCopiedEncodedData implements EncodedData {
    private final MediaCodec.BufferInfo mBufferInfo;
    private final ByteBuffer mByteBuffer;
    private final CallbackToFutureAdapter.Completer mClosedCompleter;
    private final ListenableFuture mClosedFuture;

    public BufferCopiedEncodedData(EncodedData encodedData) {
        this.mBufferInfo = generateCopiedByteInfo(encodedData);
        this.mByteBuffer = generateCopiedByteBuffer(encodedData);
        final AtomicReference atomicReference = new AtomicReference();
        this.mClosedFuture = CallbackToFutureAdapter.getFuture(new CallbackToFutureAdapter.Resolver() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.video.internal.encoder.BufferCopiedEncodedData$$ExternalSyntheticLambda0
            @Override // androidx.concurrent.futures.CallbackToFutureAdapter.Resolver
            public final Object attachCompleter(CallbackToFutureAdapter.Completer completer) {
                return BufferCopiedEncodedData.$r8$lambda$t8pbauSrmDajdzuuc1Z7c3lfEqA(atomicReference, completer);
            }
        });
        this.mClosedCompleter = (CallbackToFutureAdapter.Completer) Preconditions.checkNotNull((CallbackToFutureAdapter.Completer) atomicReference.get());
    }

    public static /* synthetic */ Object $r8$lambda$t8pbauSrmDajdzuuc1Z7c3lfEqA(AtomicReference atomicReference, CallbackToFutureAdapter.Completer completer) {
        atomicReference.set(completer);
        return "Data closed";
    }

    private MediaCodec.BufferInfo generateCopiedByteInfo(EncodedData encodedData) {
        MediaCodec.BufferInfo bufferInfo = encodedData.getBufferInfo();
        MediaCodec.BufferInfo bufferInfo2 = new MediaCodec.BufferInfo();
        bufferInfo2.set(0, bufferInfo.size, bufferInfo.presentationTimeUs, bufferInfo.flags);
        return bufferInfo2;
    }

    private ByteBuffer generateCopiedByteBuffer(EncodedData encodedData) {
        ByteBuffer byteBuffer = encodedData.getByteBuffer();
        MediaCodec.BufferInfo bufferInfo = encodedData.getBufferInfo();
        byteBuffer.position(bufferInfo.offset);
        byteBuffer.limit(bufferInfo.offset + bufferInfo.size);
        ByteBuffer byteBufferAllocate = ByteBuffer.allocate(bufferInfo.size);
        byteBufferAllocate.order(byteBuffer.order());
        byteBufferAllocate.put(byteBuffer);
        byteBufferAllocate.flip();
        return byteBufferAllocate;
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.video.internal.encoder.EncodedData
    public ByteBuffer getByteBuffer() {
        return this.mByteBuffer;
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.video.internal.encoder.EncodedData
    public MediaCodec.BufferInfo getBufferInfo() {
        return this.mBufferInfo;
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.video.internal.encoder.EncodedData
    public long getPresentationTimeUs() {
        return this.mBufferInfo.presentationTimeUs;
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.video.internal.encoder.EncodedData
    public long size() {
        return this.mBufferInfo.size;
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.video.internal.encoder.EncodedData
    public boolean isKeyFrame() {
        return (this.mBufferInfo.flags & 1) != 0;
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.video.internal.encoder.EncodedData, java.lang.AutoCloseable
    public void close() {
        this.mClosedCompleter.set(null);
    }
}
