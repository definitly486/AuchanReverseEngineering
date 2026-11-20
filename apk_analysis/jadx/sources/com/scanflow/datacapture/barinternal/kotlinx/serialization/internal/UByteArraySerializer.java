package com.scanflow.datacapture.barinternal.kotlinx.serialization.internal;

import com.scanflow.datacapture.barinternal.kotlin.UByte;
import com.scanflow.datacapture.barinternal.kotlin.UByteArray;
import kotlin.jvm.internal.Intrinsics;
import kotlinx.serialization.KSerializer;
import kotlinx.serialization.builtins.BuiltinSerializersKt;
import kotlinx.serialization.encoding.CompositeDecoder;
import kotlinx.serialization.encoding.CompositeEncoder;

/* JADX INFO: compiled from: PrimitiveArraysSerializers.kt */
/* JADX INFO: loaded from: classes3.dex */
public final class UByteArraySerializer extends PrimitiveArraySerializer implements KSerializer {
    public static final UByteArraySerializer INSTANCE = new UByteArraySerializer();

    @Override // com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.AbstractCollectionSerializer
    public /* bridge */ /* synthetic */ int collectionSize(Object obj) {
        return m877collectionSizeGBYM_sE(((UByteArray) obj).m709unboximpl());
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.PrimitiveArraySerializer
    public /* bridge */ /* synthetic */ Object empty() {
        return UByteArray.m695boximpl(m878emptyTcUX1vc());
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.AbstractCollectionSerializer
    public /* bridge */ /* synthetic */ Object toBuilder(Object obj) {
        return m879toBuilderGBYM_sE(((UByteArray) obj).m709unboximpl());
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.PrimitiveArraySerializer
    public /* bridge */ /* synthetic */ void writeContent(CompositeEncoder compositeEncoder, Object obj, int i) {
        m880writeContentCoi6ktg(compositeEncoder, ((UByteArray) obj).m709unboximpl(), i);
    }

    private UByteArraySerializer() {
        super(BuiltinSerializersKt.serializer(UByte.Companion));
    }

    /* JADX INFO: renamed from: collectionSize-GBYM_sE, reason: not valid java name */
    protected int m877collectionSizeGBYM_sE(byte[] collectionSize) {
        Intrinsics.checkNotNullParameter(collectionSize, "$this$collectionSize");
        return UByteArray.m702getSizeimpl(collectionSize);
    }

    /* JADX INFO: renamed from: toBuilder-GBYM_sE, reason: not valid java name */
    protected UByteArrayBuilder m879toBuilderGBYM_sE(byte[] toBuilder) {
        Intrinsics.checkNotNullParameter(toBuilder, "$this$toBuilder");
        return new UByteArrayBuilder(toBuilder, null);
    }

    /* JADX INFO: renamed from: empty-TcUX1vc, reason: not valid java name */
    protected byte[] m878emptyTcUX1vc() {
        return UByteArray.m696constructorimpl(0);
    }

    /* JADX INFO: Access modifiers changed from: protected */
    @Override // com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.CollectionLikeSerializer, com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.AbstractCollectionSerializer
    public void readElement(CompositeDecoder decoder, int i, UByteArrayBuilder builder, boolean z) {
        Intrinsics.checkNotNullParameter(decoder, "decoder");
        Intrinsics.checkNotNullParameter(builder, "builder");
        builder.m875append7apg3OU$kotlinx_serialization_core(UByte.m690constructorimpl(decoder.decodeInlineElement(getDescriptor(), i).decodeByte()));
    }

    /* JADX INFO: renamed from: writeContent-Coi6ktg, reason: not valid java name */
    protected void m880writeContentCoi6ktg(CompositeEncoder encoder, byte[] content, int i) {
        Intrinsics.checkNotNullParameter(encoder, "encoder");
        Intrinsics.checkNotNullParameter(content, "content");
        for (int i2 = 0; i2 < i; i2++) {
            encoder.encodeInlineElement(getDescriptor(), i2).encodeByte(UByteArray.m701getw2LRezQ(content, i2));
        }
    }
}
