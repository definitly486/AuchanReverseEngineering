package com.scanflow.datacapture.barinternal.kotlinx.serialization.internal;

import com.scanflow.datacapture.barinternal.kotlin.ULong;
import com.scanflow.datacapture.barinternal.kotlin.ULongArray;
import kotlin.jvm.internal.Intrinsics;
import kotlinx.serialization.KSerializer;
import kotlinx.serialization.builtins.BuiltinSerializersKt;
import kotlinx.serialization.encoding.CompositeDecoder;
import kotlinx.serialization.encoding.CompositeEncoder;

/* JADX INFO: compiled from: PrimitiveArraysSerializers.kt */
/* JADX INFO: loaded from: classes3.dex */
public final class ULongArraySerializer extends PrimitiveArraySerializer implements KSerializer {
    public static final ULongArraySerializer INSTANCE = new ULongArraySerializer();

    @Override // com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.AbstractCollectionSerializer
    public /* bridge */ /* synthetic */ int collectionSize(Object obj) {
        return m893collectionSizeQwZRm1k(((ULongArray) obj).m753unboximpl());
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.PrimitiveArraySerializer
    public /* bridge */ /* synthetic */ Object empty() {
        return ULongArray.m739boximpl(m894emptyY2RjT0g());
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.AbstractCollectionSerializer
    public /* bridge */ /* synthetic */ Object toBuilder(Object obj) {
        return m895toBuilderQwZRm1k(((ULongArray) obj).m753unboximpl());
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.PrimitiveArraySerializer
    public /* bridge */ /* synthetic */ void writeContent(CompositeEncoder compositeEncoder, Object obj, int i) {
        m896writeContent0q3Fkuo(compositeEncoder, ((ULongArray) obj).m753unboximpl(), i);
    }

    private ULongArraySerializer() {
        super(BuiltinSerializersKt.serializer(ULong.Companion));
    }

    /* JADX INFO: renamed from: collectionSize-QwZRm1k, reason: not valid java name */
    protected int m893collectionSizeQwZRm1k(long[] collectionSize) {
        Intrinsics.checkNotNullParameter(collectionSize, "$this$collectionSize");
        return ULongArray.m746getSizeimpl(collectionSize);
    }

    /* JADX INFO: renamed from: toBuilder-QwZRm1k, reason: not valid java name */
    protected ULongArrayBuilder m895toBuilderQwZRm1k(long[] toBuilder) {
        Intrinsics.checkNotNullParameter(toBuilder, "$this$toBuilder");
        return new ULongArrayBuilder(toBuilder, null);
    }

    /* JADX INFO: renamed from: empty-Y2RjT0g, reason: not valid java name */
    protected long[] m894emptyY2RjT0g() {
        return ULongArray.m740constructorimpl(0);
    }

    /* JADX INFO: Access modifiers changed from: protected */
    @Override // com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.CollectionLikeSerializer, com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.AbstractCollectionSerializer
    public void readElement(CompositeDecoder decoder, int i, ULongArrayBuilder builder, boolean z) {
        Intrinsics.checkNotNullParameter(decoder, "decoder");
        Intrinsics.checkNotNullParameter(builder, "builder");
        builder.m891appendVKZWuLQ$kotlinx_serialization_core(ULong.m734constructorimpl(decoder.decodeInlineElement(getDescriptor(), i).decodeLong()));
    }

    /* JADX INFO: renamed from: writeContent-0q3Fkuo, reason: not valid java name */
    protected void m896writeContent0q3Fkuo(CompositeEncoder encoder, long[] content, int i) {
        Intrinsics.checkNotNullParameter(encoder, "encoder");
        Intrinsics.checkNotNullParameter(content, "content");
        for (int i2 = 0; i2 < i; i2++) {
            encoder.encodeInlineElement(getDescriptor(), i2).encodeLong(ULongArray.m745getsVKNKU(content, i2));
        }
    }
}
