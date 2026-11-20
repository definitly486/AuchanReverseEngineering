package com.scanflow.datacapture.barinternal.kotlinx.serialization.internal;

import com.scanflow.datacapture.barinternal.kotlin.UShort;
import com.scanflow.datacapture.barinternal.kotlin.UShortArray;
import kotlin.jvm.internal.Intrinsics;
import kotlinx.serialization.KSerializer;
import kotlinx.serialization.builtins.BuiltinSerializersKt;
import kotlinx.serialization.encoding.CompositeDecoder;
import kotlinx.serialization.encoding.CompositeEncoder;

/* JADX INFO: compiled from: PrimitiveArraysSerializers.kt */
/* JADX INFO: loaded from: classes3.dex */
public final class UShortArraySerializer extends PrimitiveArraySerializer implements KSerializer {
    public static final UShortArraySerializer INSTANCE = new UShortArraySerializer();

    @Override // com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.AbstractCollectionSerializer
    public /* bridge */ /* synthetic */ int collectionSize(Object obj) {
        return m901collectionSizerL5Bavg(((UShortArray) obj).m775unboximpl());
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.PrimitiveArraySerializer
    public /* bridge */ /* synthetic */ Object empty() {
        return UShortArray.m761boximpl(m902emptyamswpOA());
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.AbstractCollectionSerializer
    public /* bridge */ /* synthetic */ Object toBuilder(Object obj) {
        return m903toBuilderrL5Bavg(((UShortArray) obj).m775unboximpl());
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.PrimitiveArraySerializer
    public /* bridge */ /* synthetic */ void writeContent(CompositeEncoder compositeEncoder, Object obj, int i) {
        m904writeContenteny0XGE(compositeEncoder, ((UShortArray) obj).m775unboximpl(), i);
    }

    private UShortArraySerializer() {
        super(BuiltinSerializersKt.serializer(UShort.Companion));
    }

    /* JADX INFO: renamed from: collectionSize-rL5Bavg, reason: not valid java name */
    protected int m901collectionSizerL5Bavg(short[] collectionSize) {
        Intrinsics.checkNotNullParameter(collectionSize, "$this$collectionSize");
        return UShortArray.m768getSizeimpl(collectionSize);
    }

    /* JADX INFO: renamed from: toBuilder-rL5Bavg, reason: not valid java name */
    protected UShortArrayBuilder m903toBuilderrL5Bavg(short[] toBuilder) {
        Intrinsics.checkNotNullParameter(toBuilder, "$this$toBuilder");
        return new UShortArrayBuilder(toBuilder, null);
    }

    /* JADX INFO: renamed from: empty-amswpOA, reason: not valid java name */
    protected short[] m902emptyamswpOA() {
        return UShortArray.m762constructorimpl(0);
    }

    /* JADX INFO: Access modifiers changed from: protected */
    @Override // com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.CollectionLikeSerializer, com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.AbstractCollectionSerializer
    public void readElement(CompositeDecoder decoder, int i, UShortArrayBuilder builder, boolean z) {
        Intrinsics.checkNotNullParameter(decoder, "decoder");
        Intrinsics.checkNotNullParameter(builder, "builder");
        builder.m899appendxj2QHRw$kotlinx_serialization_core(UShort.m756constructorimpl(decoder.decodeInlineElement(getDescriptor(), i).decodeShort()));
    }

    /* JADX INFO: renamed from: writeContent-eny0XGE, reason: not valid java name */
    protected void m904writeContenteny0XGE(CompositeEncoder encoder, short[] content, int i) {
        Intrinsics.checkNotNullParameter(encoder, "encoder");
        Intrinsics.checkNotNullParameter(content, "content");
        for (int i2 = 0; i2 < i; i2++) {
            encoder.encodeInlineElement(getDescriptor(), i2).encodeShort(UShortArray.m767getMh2AYeg(content, i2));
        }
    }
}
