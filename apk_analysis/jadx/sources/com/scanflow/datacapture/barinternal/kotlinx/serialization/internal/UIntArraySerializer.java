package com.scanflow.datacapture.barinternal.kotlinx.serialization.internal;

import com.scanflow.datacapture.barinternal.kotlin.UInt;
import com.scanflow.datacapture.barinternal.kotlin.UIntArray;
import kotlin.jvm.internal.Intrinsics;
import kotlinx.serialization.KSerializer;
import kotlinx.serialization.builtins.BuiltinSerializersKt;
import kotlinx.serialization.encoding.CompositeDecoder;
import kotlinx.serialization.encoding.CompositeEncoder;

/* JADX INFO: compiled from: PrimitiveArraysSerializers.kt */
/* JADX INFO: loaded from: classes3.dex */
public final class UIntArraySerializer extends PrimitiveArraySerializer implements KSerializer {
    public static final UIntArraySerializer INSTANCE = new UIntArraySerializer();

    @Override // com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.AbstractCollectionSerializer
    public /* bridge */ /* synthetic */ int collectionSize(Object obj) {
        return m885collectionSizeajY9A(((UIntArray) obj).m731unboximpl());
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.PrimitiveArraySerializer
    public /* bridge */ /* synthetic */ Object empty() {
        return UIntArray.m717boximpl(m886emptyhP7Qyg());
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.AbstractCollectionSerializer
    public /* bridge */ /* synthetic */ Object toBuilder(Object obj) {
        return m887toBuilderajY9A(((UIntArray) obj).m731unboximpl());
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.PrimitiveArraySerializer
    public /* bridge */ /* synthetic */ void writeContent(CompositeEncoder compositeEncoder, Object obj, int i) {
        m888writeContentCPlH8fI(compositeEncoder, ((UIntArray) obj).m731unboximpl(), i);
    }

    private UIntArraySerializer() {
        super(BuiltinSerializersKt.serializer(UInt.Companion));
    }

    /* JADX INFO: renamed from: collectionSize--ajY-9A, reason: not valid java name */
    protected int m885collectionSizeajY9A(int[] collectionSize) {
        Intrinsics.checkNotNullParameter(collectionSize, "$this$collectionSize");
        return UIntArray.m724getSizeimpl(collectionSize);
    }

    /* JADX INFO: renamed from: toBuilder--ajY-9A, reason: not valid java name */
    protected UIntArrayBuilder m887toBuilderajY9A(int[] toBuilder) {
        Intrinsics.checkNotNullParameter(toBuilder, "$this$toBuilder");
        return new UIntArrayBuilder(toBuilder, null);
    }

    /* JADX INFO: renamed from: empty--hP7Qyg, reason: not valid java name */
    protected int[] m886emptyhP7Qyg() {
        return UIntArray.m718constructorimpl(0);
    }

    /* JADX INFO: Access modifiers changed from: protected */
    @Override // com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.CollectionLikeSerializer, com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.AbstractCollectionSerializer
    public void readElement(CompositeDecoder decoder, int i, UIntArrayBuilder builder, boolean z) {
        Intrinsics.checkNotNullParameter(decoder, "decoder");
        Intrinsics.checkNotNullParameter(builder, "builder");
        builder.m883appendWZ4Q5Ns$kotlinx_serialization_core(UInt.m712constructorimpl(decoder.decodeInlineElement(getDescriptor(), i).decodeInt()));
    }

    /* JADX INFO: renamed from: writeContent-CPlH8fI, reason: not valid java name */
    protected void m888writeContentCPlH8fI(CompositeEncoder encoder, int[] content, int i) {
        Intrinsics.checkNotNullParameter(encoder, "encoder");
        Intrinsics.checkNotNullParameter(content, "content");
        for (int i2 = 0; i2 < i; i2++) {
            encoder.encodeInlineElement(getDescriptor(), i2).encodeInt(UIntArray.m723getpVg5ArA(content, i2));
        }
    }
}
