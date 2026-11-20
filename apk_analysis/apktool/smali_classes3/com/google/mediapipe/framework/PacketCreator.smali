.class public Lcom/google/mediapipe/framework/PacketCreator;
.super Ljava/lang/Object;
.source "PacketCreator.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/mediapipe/framework/PacketCreator$SyncMode;
    }
.end annotation


# static fields
.field private static final GL_RGBA:I = 0x1908


# instance fields
.field protected mediapipeGraph:Lcom/google/mediapipe/framework/Graph;


# direct methods
.method public constructor <init>(Lcom/google/mediapipe/framework/Graph;)V
    .locals 0

    .line 55
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 56
    iput-object p1, p0, Lcom/google/mediapipe/framework/PacketCreator;->mediapipeGraph:Lcom/google/mediapipe/framework/Graph;

    return-void
.end method

.method private static checkAudioDataSize(III)V
    .locals 2

    mul-int/2addr p1, p2

    mul-int/lit8 p1, p1, 0x2

    if-ne p1, p0, :cond_0

    return-void

    .line 139
    :cond_0
    new-instance p2, Ljava/lang/IllegalArgumentException;

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "Please check the audio data size, has to be num_channels * num_samples * 2 = "

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0, p1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string p1, " but was "

    invoke-virtual {v0, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0, p0}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p0

    invoke-direct {p2, p0}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p2
.end method

.method private native nativeCreateAudioPacket(J[BIII)J
.end method

.method private native nativeCreateAudioPacketDirect(JLjava/nio/ByteBuffer;II)J
.end method

.method private native nativeCreateBool(JZ)J
.end method

.method private native nativeCreateCalculatorOptions(J[B)J
.end method

.method private native nativeCreateCameraIntrinsics(JFFFFFF)J
.end method

.method private native nativeCreateCpuImage(JLjava/nio/ByteBuffer;IIII)J
.end method

.method private native nativeCreateFloat32(JF)J
.end method

.method private native nativeCreateFloat32Array(J[F)J
.end method

.method private native nativeCreateFloat32Vector(J[F)J
.end method

.method private native nativeCreateFloat64(JD)J
.end method

.method private native nativeCreateFloatImageFrame(JLjava/nio/FloatBuffer;II)J
.end method

.method private native nativeCreateGpuBuffer(JIIIILcom/google/mediapipe/framework/TextureReleaseCallback;I)J
.end method

.method private native nativeCreateGpuImage(JIIIILcom/google/mediapipe/framework/TextureReleaseCallback;)J
.end method

.method private native nativeCreateGrayscaleImage(JLjava/nio/ByteBuffer;II)J
.end method

.method private native nativeCreateInt16(JS)J
.end method

.method private native nativeCreateInt32(JI)J
.end method

.method private native nativeCreateInt32Array(J[I)J
.end method

.method private native nativeCreateInt32Pair(JII)J
.end method

.method private native nativeCreateInt64(JJ)J
.end method

.method private native nativeCreateMatrix(JII[F)J
.end method

.method private native nativeCreateProto(JLcom/google/mediapipe/framework/ProtoUtil$SerializedMessage;)J
.end method

.method private native nativeCreateReferencePacket(JJ)J
.end method

.method private native nativeCreateRgbImage(JLjava/nio/ByteBuffer;II)J
.end method

.method private native nativeCreateRgbImageFromRgba(JLjava/nio/ByteBuffer;II)J
.end method

.method private native nativeCreateRgbaImageFrame(JLjava/nio/ByteBuffer;II)J
.end method

.method private native nativeCreateString(JLjava/lang/String;)J
.end method

.method private native nativeCreateStringFromByteArray(J[B)J
.end method

.method private native nativeCreateTimeSeriesHeader(JID)J
.end method

.method private native nativeCreateVideoHeader(JII)J
.end method

.method private releaseWithSyncToken(JLcom/google/mediapipe/framework/TextureReleaseCallback;)V
    .locals 1

    .line 481
    new-instance v0, Lcom/google/mediapipe/framework/GraphGlSyncToken;

    invoke-direct {v0, p1, p2}, Lcom/google/mediapipe/framework/GraphGlSyncToken;-><init>(J)V

    invoke-interface {p3, v0}, Lcom/google/mediapipe/framework/TextureReleaseCallback;->release(Lcom/google/mediapipe/framework/GlSyncToken;)V

    return-void
.end method


# virtual methods
.method public createAudioPacket(Ljava/nio/ByteBuffer;II)Lcom/google/mediapipe/framework/Packet;
    .locals 7

    .line 117
    invoke-virtual {p1}, Ljava/nio/Buffer;->remaining()I

    move-result v0

    invoke-static {v0, p2, p3}, Lcom/google/mediapipe/framework/PacketCreator;->checkAudioDataSize(III)V

    .line 118
    invoke-virtual {p1}, Ljava/nio/ByteBuffer;->isDirect()Z

    move-result v0

    if-eqz v0, :cond_0

    .line 119
    iget-object v0, p0, Lcom/google/mediapipe/framework/PacketCreator;->mediapipeGraph:Lcom/google/mediapipe/framework/Graph;

    .line 121
    invoke-virtual {v0}, Lcom/google/mediapipe/framework/Graph;->getNativeHandle()J

    move-result-wide v2

    invoke-virtual {p1}, Ljava/nio/ByteBuffer;->slice()Ljava/nio/ByteBuffer;

    move-result-object v4

    move-object v1, p0

    move v5, p2

    move v6, p3

    .line 120
    invoke-direct/range {v1 .. v6}, Lcom/google/mediapipe/framework/PacketCreator;->nativeCreateAudioPacketDirect(JLjava/nio/ByteBuffer;II)J

    move-result-wide p1

    move-object v0, v1

    .line 119
    invoke-static {p1, p2}, Lcom/google/mediapipe/framework/Packet;->create(J)Lcom/google/mediapipe/framework/Packet;

    move-result-object p1

    return-object p1

    :cond_0
    move-object v0, p0

    move v5, p2

    move v6, p3

    .line 122
    invoke-virtual {p1}, Ljava/nio/ByteBuffer;->hasArray()Z

    move-result p2

    if-eqz p2, :cond_1

    .line 123
    iget-object p2, v0, Lcom/google/mediapipe/framework/PacketCreator;->mediapipeGraph:Lcom/google/mediapipe/framework/Graph;

    .line 125
    invoke-virtual {p2}, Lcom/google/mediapipe/framework/Graph;->getNativeHandle()J

    move-result-wide v1

    .line 126
    invoke-virtual {p1}, Ljava/nio/ByteBuffer;->array()[B

    move-result-object v3

    .line 127
    invoke-virtual {p1}, Ljava/nio/ByteBuffer;->arrayOffset()I

    move-result p2

    invoke-virtual {p1}, Ljava/nio/Buffer;->position()I

    move-result p1

    add-int v4, p2, p1

    .line 124
    invoke-direct/range {v0 .. v6}, Lcom/google/mediapipe/framework/PacketCreator;->nativeCreateAudioPacket(J[BIII)J

    move-result-wide p1

    .line 123
    invoke-static {p1, p2}, Lcom/google/mediapipe/framework/Packet;->create(J)Lcom/google/mediapipe/framework/Packet;

    move-result-object p1

    return-object p1

    .line 131
    :cond_1
    new-instance p1, Ljava/lang/IllegalArgumentException;

    const-string p2, "Data must be either a direct byte buffer or be backed by a byte array."

    invoke-direct {p1, p2}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public createAudioPacket([BII)Lcom/google/mediapipe/framework/Packet;
    .locals 8

    .line 100
    array-length v0, p1

    invoke-static {v0, p2, p3}, Lcom/google/mediapipe/framework/PacketCreator;->checkAudioDataSize(III)V

    .line 101
    iget-object v0, p0, Lcom/google/mediapipe/framework/PacketCreator;->mediapipeGraph:Lcom/google/mediapipe/framework/Graph;

    .line 103
    invoke-virtual {v0}, Lcom/google/mediapipe/framework/Graph;->getNativeHandle()J

    move-result-wide v2

    const/4 v5, 0x0

    move-object v1, p0

    move-object v4, p1

    move v6, p2

    move v7, p3

    .line 102
    invoke-direct/range {v1 .. v7}, Lcom/google/mediapipe/framework/PacketCreator;->nativeCreateAudioPacket(J[BIII)J

    move-result-wide p1

    .line 101
    invoke-static {p1, p2}, Lcom/google/mediapipe/framework/Packet;->create(J)Lcom/google/mediapipe/framework/Packet;

    move-result-object p1

    return-object p1
.end method

.method public createBool(Z)Lcom/google/mediapipe/framework/Packet;
    .locals 2

    .line 233
    iget-object v0, p0, Lcom/google/mediapipe/framework/PacketCreator;->mediapipeGraph:Lcom/google/mediapipe/framework/Graph;

    invoke-virtual {v0}, Lcom/google/mediapipe/framework/Graph;->getNativeHandle()J

    move-result-wide v0

    invoke-direct {p0, v0, v1, p1}, Lcom/google/mediapipe/framework/PacketCreator;->nativeCreateBool(JZ)J

    move-result-wide v0

    invoke-static {v0, v1}, Lcom/google/mediapipe/framework/Packet;->create(J)Lcom/google/mediapipe/framework/Packet;

    move-result-object p1

    return-object p1
.end method

.method public createByteArray([B)Lcom/google/mediapipe/framework/Packet;
    .locals 2

    .line 273
    iget-object v0, p0, Lcom/google/mediapipe/framework/PacketCreator;->mediapipeGraph:Lcom/google/mediapipe/framework/Graph;

    invoke-virtual {v0}, Lcom/google/mediapipe/framework/Graph;->getNativeHandle()J

    move-result-wide v0

    invoke-direct {p0, v0, v1, p1}, Lcom/google/mediapipe/framework/PacketCreator;->nativeCreateStringFromByteArray(J[B)J

    move-result-wide v0

    invoke-static {v0, v1}, Lcom/google/mediapipe/framework/Packet;->create(J)Lcom/google/mediapipe/framework/Packet;

    move-result-object p1

    return-object p1
.end method

.method public createCalculatorOptions(Lcom/google/protobuf/MessageLite;)Lcom/google/mediapipe/framework/Packet;
    .locals 2

    .line 309
    iget-object v0, p0, Lcom/google/mediapipe/framework/PacketCreator;->mediapipeGraph:Lcom/google/mediapipe/framework/Graph;

    .line 310
    invoke-virtual {v0}, Lcom/google/mediapipe/framework/Graph;->getNativeHandle()J

    move-result-wide v0

    invoke-interface {p1}, Lcom/google/protobuf/MessageLite;->toByteArray()[B

    move-result-object p1

    invoke-direct {p0, v0, v1, p1}, Lcom/google/mediapipe/framework/PacketCreator;->nativeCreateCalculatorOptions(J[B)J

    move-result-wide v0

    .line 309
    invoke-static {v0, v1}, Lcom/google/mediapipe/framework/Packet;->create(J)Lcom/google/mediapipe/framework/Packet;

    move-result-object p1

    return-object p1
.end method

.method public createCameraIntrinsics(FFFFFF)Lcom/google/mediapipe/framework/Packet;
    .locals 9

    .line 322
    iget-object v1, p0, Lcom/google/mediapipe/framework/PacketCreator;->mediapipeGraph:Lcom/google/mediapipe/framework/Graph;

    .line 324
    invoke-virtual {v1}, Lcom/google/mediapipe/framework/Graph;->getNativeHandle()J

    move-result-wide v1

    move-object v0, p0

    move v3, p1

    move v4, p2

    move v5, p3

    move v6, p4

    move v7, p5

    move v8, p6

    .line 323
    invoke-direct/range {v0 .. v8}, Lcom/google/mediapipe/framework/PacketCreator;->nativeCreateCameraIntrinsics(JFFFFFF)J

    move-result-wide v1

    .line 322
    invoke-static {v1, v2}, Lcom/google/mediapipe/framework/Packet;->create(J)Lcom/google/mediapipe/framework/Packet;

    move-result-object v0

    return-object v0
.end method

.method public createFloat32(F)Lcom/google/mediapipe/framework/Packet;
    .locals 2

    .line 225
    iget-object v0, p0, Lcom/google/mediapipe/framework/PacketCreator;->mediapipeGraph:Lcom/google/mediapipe/framework/Graph;

    invoke-virtual {v0}, Lcom/google/mediapipe/framework/Graph;->getNativeHandle()J

    move-result-wide v0

    invoke-direct {p0, v0, v1, p1}, Lcom/google/mediapipe/framework/PacketCreator;->nativeCreateFloat32(JF)J

    move-result-wide v0

    invoke-static {v0, v1}, Lcom/google/mediapipe/framework/Packet;->create(J)Lcom/google/mediapipe/framework/Packet;

    move-result-object p1

    return-object p1
.end method

.method public createFloat32Array([F)Lcom/google/mediapipe/framework/Packet;
    .locals 2

    .line 269
    iget-object v0, p0, Lcom/google/mediapipe/framework/PacketCreator;->mediapipeGraph:Lcom/google/mediapipe/framework/Graph;

    invoke-virtual {v0}, Lcom/google/mediapipe/framework/Graph;->getNativeHandle()J

    move-result-wide v0

    invoke-direct {p0, v0, v1, p1}, Lcom/google/mediapipe/framework/PacketCreator;->nativeCreateFloat32Array(J[F)J

    move-result-wide v0

    invoke-static {v0, v1}, Lcom/google/mediapipe/framework/Packet;->create(J)Lcom/google/mediapipe/framework/Packet;

    move-result-object p1

    return-object p1
.end method

.method public createFloat32Vector([F)Lcom/google/mediapipe/framework/Packet;
    .locals 2

    .line 253
    iget-object v0, p0, Lcom/google/mediapipe/framework/PacketCreator;->mediapipeGraph:Lcom/google/mediapipe/framework/Graph;

    invoke-virtual {v0}, Lcom/google/mediapipe/framework/Graph;->getNativeHandle()J

    move-result-wide v0

    invoke-direct {p0, v0, v1, p1}, Lcom/google/mediapipe/framework/PacketCreator;->nativeCreateFloat32Vector(J[F)J

    move-result-wide v0

    invoke-static {v0, v1}, Lcom/google/mediapipe/framework/Packet;->create(J)Lcom/google/mediapipe/framework/Packet;

    move-result-object p1

    return-object p1
.end method

.method public createFloat64(D)Lcom/google/mediapipe/framework/Packet;
    .locals 2

    .line 229
    iget-object v0, p0, Lcom/google/mediapipe/framework/PacketCreator;->mediapipeGraph:Lcom/google/mediapipe/framework/Graph;

    invoke-virtual {v0}, Lcom/google/mediapipe/framework/Graph;->getNativeHandle()J

    move-result-wide v0

    invoke-direct {p0, v0, v1, p1, p2}, Lcom/google/mediapipe/framework/PacketCreator;->nativeCreateFloat64(JD)J

    move-result-wide p1

    invoke-static {p1, p2}, Lcom/google/mediapipe/framework/Packet;->create(J)Lcom/google/mediapipe/framework/Packet;

    move-result-object p1

    return-object p1
.end method

.method public createFloat64Vector([D)Lcom/google/mediapipe/framework/Packet;
    .locals 1

    .line 257
    new-instance p1, Ljava/lang/UnsupportedOperationException;

    const-string v0, "Not implemented yet"

    invoke-direct {p1, v0}, Ljava/lang/UnsupportedOperationException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public createFloatImageFrame(Ljava/nio/FloatBuffer;II)Lcom/google/mediapipe/framework/Packet;
    .locals 7

    .line 201
    invoke-virtual {p1}, Ljava/nio/Buffer;->capacity()I

    move-result v0

    mul-int v1, p2, p3

    mul-int/lit8 v1, v1, 0x4

    if-ne v0, v1, :cond_0

    .line 208
    iget-object v0, p0, Lcom/google/mediapipe/framework/PacketCreator;->mediapipeGraph:Lcom/google/mediapipe/framework/Graph;

    .line 209
    invoke-virtual {v0}, Lcom/google/mediapipe/framework/Graph;->getNativeHandle()J

    move-result-wide v2

    move-object v1, p0

    move-object v4, p1

    move v5, p2

    move v6, p3

    invoke-direct/range {v1 .. v6}, Lcom/google/mediapipe/framework/PacketCreator;->nativeCreateFloatImageFrame(JLjava/nio/FloatBuffer;II)J

    move-result-wide p1

    .line 208
    invoke-static {p1, p2}, Lcom/google/mediapipe/framework/Packet;->create(J)Lcom/google/mediapipe/framework/Packet;

    move-result-object p1

    return-object p1

    :cond_0
    move-object v4, p1

    .line 202
    new-instance p1, Ljava/lang/IllegalArgumentException;

    new-instance p2, Ljava/lang/StringBuilder;

    invoke-direct {p2}, Ljava/lang/StringBuilder;-><init>()V

    const-string p3, "The size of the buffer should be: "

    invoke-virtual {p2, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p2, v1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string p3, " but is "

    invoke-virtual {p2, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 206
    invoke-virtual {v4}, Ljava/nio/Buffer;->capacity()I

    move-result p3

    invoke-virtual {p2, p3}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {p2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p2

    invoke-direct {p1, p2}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public createGpuBuffer(III)Lcom/google/mediapipe/framework/Packet;
    .locals 6
    .annotation runtime Ljava/lang/Deprecated;
    .end annotation

    const/16 v4, 0x1908

    const/4 v5, 0x0

    move-object v0, p0

    move v1, p1

    move v2, p2

    move v3, p3

    .line 401
    invoke-virtual/range {v0 .. v5}, Lcom/google/mediapipe/framework/PacketCreator;->createGpuBuffer(IIIILcom/google/mediapipe/framework/TextureReleaseCallback;)Lcom/google/mediapipe/framework/Packet;

    move-result-object p1

    return-object p1
.end method

.method public createGpuBuffer(IIIILcom/google/mediapipe/framework/TextureReleaseCallback;)Lcom/google/mediapipe/framework/Packet;
    .locals 7

    .line 363
    sget-object v6, Lcom/google/mediapipe/framework/PacketCreator$SyncMode;->NO_SYNC:Lcom/google/mediapipe/framework/PacketCreator$SyncMode;

    move-object v0, p0

    move v1, p1

    move v2, p2

    move v3, p3

    move v4, p4

    move-object v5, p5

    invoke-virtual/range {v0 .. v6}, Lcom/google/mediapipe/framework/PacketCreator;->createGpuBuffer(IIIILcom/google/mediapipe/framework/TextureReleaseCallback;Lcom/google/mediapipe/framework/PacketCreator$SyncMode;)Lcom/google/mediapipe/framework/Packet;

    move-result-object p1

    return-object p1
.end method

.method public createGpuBuffer(IIIILcom/google/mediapipe/framework/TextureReleaseCallback;Lcom/google/mediapipe/framework/PacketCreator$SyncMode;)Lcom/google/mediapipe/framework/Packet;
    .locals 9

    .line 346
    iget-object v1, p0, Lcom/google/mediapipe/framework/PacketCreator;->mediapipeGraph:Lcom/google/mediapipe/framework/Graph;

    .line 348
    invoke-virtual {v1}, Lcom/google/mediapipe/framework/Graph;->getNativeHandle()J

    move-result-wide v1

    .line 354
    invoke-static {p6}, Lcom/google/mediapipe/framework/PacketCreator$SyncMode;->access$000(Lcom/google/mediapipe/framework/PacketCreator$SyncMode;)I

    move-result v8

    move-object v0, p0

    move v3, p1

    move v4, p2

    move v5, p3

    move v6, p4

    move-object v7, p5

    .line 347
    invoke-direct/range {v0 .. v8}, Lcom/google/mediapipe/framework/PacketCreator;->nativeCreateGpuBuffer(JIIIILcom/google/mediapipe/framework/TextureReleaseCallback;I)J

    move-result-wide v1

    .line 346
    invoke-static {v1, v2}, Lcom/google/mediapipe/framework/Packet;->create(J)Lcom/google/mediapipe/framework/Packet;

    move-result-object v0

    return-object v0
.end method

.method public createGpuBuffer(IIILcom/google/mediapipe/framework/TextureReleaseCallback;)Lcom/google/mediapipe/framework/Packet;
    .locals 6

    .line 388
    sget-object v5, Lcom/google/mediapipe/framework/PacketCreator$SyncMode;->NO_SYNC:Lcom/google/mediapipe/framework/PacketCreator$SyncMode;

    move-object v0, p0

    move v1, p1

    move v2, p2

    move v3, p3

    move-object v4, p4

    invoke-virtual/range {v0 .. v5}, Lcom/google/mediapipe/framework/PacketCreator;->createGpuBuffer(IIILcom/google/mediapipe/framework/TextureReleaseCallback;Lcom/google/mediapipe/framework/PacketCreator$SyncMode;)Lcom/google/mediapipe/framework/Packet;

    move-result-object p1

    return-object p1
.end method

.method public createGpuBuffer(IIILcom/google/mediapipe/framework/TextureReleaseCallback;Lcom/google/mediapipe/framework/PacketCreator$SyncMode;)Lcom/google/mediapipe/framework/Packet;
    .locals 7

    const/16 v4, 0x1908

    move-object v0, p0

    move v1, p1

    move v2, p2

    move v3, p3

    move-object v5, p4

    move-object v6, p5

    .line 379
    invoke-virtual/range {v0 .. v6}, Lcom/google/mediapipe/framework/PacketCreator;->createGpuBuffer(IIIILcom/google/mediapipe/framework/TextureReleaseCallback;Lcom/google/mediapipe/framework/PacketCreator$SyncMode;)Lcom/google/mediapipe/framework/Packet;

    move-result-object p1

    return-object p1
.end method

.method public createGpuBuffer(Lcom/google/mediapipe/framework/TextureFrame;)Lcom/google/mediapipe/framework/Packet;
    .locals 1

    .line 429
    sget-object v0, Lcom/google/mediapipe/framework/PacketCreator$SyncMode;->NO_SYNC:Lcom/google/mediapipe/framework/PacketCreator$SyncMode;

    invoke-virtual {p0, p1, v0}, Lcom/google/mediapipe/framework/PacketCreator;->createGpuBuffer(Lcom/google/mediapipe/framework/TextureFrame;Lcom/google/mediapipe/framework/PacketCreator$SyncMode;)Lcom/google/mediapipe/framework/Packet;

    move-result-object p1

    return-object p1
.end method

.method public createGpuBuffer(Lcom/google/mediapipe/framework/TextureFrame;Lcom/google/mediapipe/framework/PacketCreator$SyncMode;)Lcom/google/mediapipe/framework/Packet;
    .locals 10

    .line 413
    iget-object v0, p0, Lcom/google/mediapipe/framework/PacketCreator;->mediapipeGraph:Lcom/google/mediapipe/framework/Graph;

    .line 415
    invoke-virtual {v0}, Lcom/google/mediapipe/framework/Graph;->getNativeHandle()J

    move-result-wide v2

    .line 416
    invoke-interface {p1}, Lcom/google/mediapipe/framework/TextureFrame;->getTextureName()I

    move-result v4

    .line 417
    invoke-interface {p1}, Lcom/google/mediapipe/framework/TextureFrame;->getWidth()I

    move-result v5

    .line 418
    invoke-interface {p1}, Lcom/google/mediapipe/framework/TextureFrame;->getHeight()I

    move-result v6

    .line 419
    invoke-interface {p1}, Lcom/google/mediapipe/framework/TextureFrame;->getFormat()I

    move-result v7

    .line 421
    invoke-static {p2}, Lcom/google/mediapipe/framework/PacketCreator$SyncMode;->access$000(Lcom/google/mediapipe/framework/PacketCreator$SyncMode;)I

    move-result v9

    move-object v1, p0

    move-object v8, p1

    .line 414
    invoke-direct/range {v1 .. v9}, Lcom/google/mediapipe/framework/PacketCreator;->nativeCreateGpuBuffer(JIIIILcom/google/mediapipe/framework/TextureReleaseCallback;I)J

    move-result-wide p1

    .line 413
    invoke-static {p1, p2}, Lcom/google/mediapipe/framework/Packet;->create(J)Lcom/google/mediapipe/framework/Packet;

    move-result-object p1

    return-object p1
.end method

.method public createGrayscaleImage(Ljava/nio/ByteBuffer;II)Lcom/google/mediapipe/framework/Packet;
    .locals 7

    mul-int v0, p2, p3

    .line 170
    invoke-virtual {p1}, Ljava/nio/Buffer;->capacity()I

    move-result v1

    if-ne v0, v1, :cond_0

    .line 174
    iget-object v0, p0, Lcom/google/mediapipe/framework/PacketCreator;->mediapipeGraph:Lcom/google/mediapipe/framework/Graph;

    .line 175
    invoke-virtual {v0}, Lcom/google/mediapipe/framework/Graph;->getNativeHandle()J

    move-result-wide v2

    move-object v1, p0

    move-object v4, p1

    move v5, p2

    move v6, p3

    invoke-direct/range {v1 .. v6}, Lcom/google/mediapipe/framework/PacketCreator;->nativeCreateGrayscaleImage(JLjava/nio/ByteBuffer;II)J

    move-result-wide p1

    .line 174
    invoke-static {p1, p2}, Lcom/google/mediapipe/framework/Packet;->create(J)Lcom/google/mediapipe/framework/Packet;

    move-result-object p1

    return-object p1

    :cond_0
    move-object v4, p1

    .line 171
    new-instance p1, Ljava/lang/IllegalArgumentException;

    new-instance p2, Ljava/lang/StringBuilder;

    invoke-direct {p2}, Ljava/lang/StringBuilder;-><init>()V

    const-string p3, "The size of the buffer should be: "

    invoke-virtual {p2, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p2, v0}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string p3, " but is "

    invoke-virtual {p2, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 172
    invoke-virtual {v4}, Ljava/nio/Buffer;->capacity()I

    move-result p3

    invoke-virtual {p2, p3}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {p2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p2

    invoke-direct {p1, p2}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public createImage(Lcom/google/mediapipe/framework/TextureFrame;)Lcom/google/mediapipe/framework/Packet;
    .locals 9

    .line 441
    iget-object v0, p0, Lcom/google/mediapipe/framework/PacketCreator;->mediapipeGraph:Lcom/google/mediapipe/framework/Graph;

    .line 443
    invoke-virtual {v0}, Lcom/google/mediapipe/framework/Graph;->getNativeHandle()J

    move-result-wide v2

    .line 444
    invoke-interface {p1}, Lcom/google/mediapipe/framework/TextureFrame;->getTextureName()I

    move-result v4

    .line 445
    invoke-interface {p1}, Lcom/google/mediapipe/framework/TextureFrame;->getWidth()I

    move-result v5

    .line 446
    invoke-interface {p1}, Lcom/google/mediapipe/framework/TextureFrame;->getHeight()I

    move-result v6

    .line 447
    invoke-interface {p1}, Lcom/google/mediapipe/framework/TextureFrame;->getFormat()I

    move-result v7

    move-object v1, p0

    move-object v8, p1

    .line 442
    invoke-direct/range {v1 .. v8}, Lcom/google/mediapipe/framework/PacketCreator;->nativeCreateGpuImage(JIIIILcom/google/mediapipe/framework/TextureReleaseCallback;)J

    move-result-wide v2

    .line 441
    invoke-static {v2, v3}, Lcom/google/mediapipe/framework/Packet;->create(J)Lcom/google/mediapipe/framework/Packet;

    move-result-object p1

    return-object p1
.end method

.method public createImage(Ljava/nio/ByteBuffer;III)Lcom/google/mediapipe/framework/Packet;
    .locals 9

    const/4 v0, 0x4

    if-ne p4, v0, :cond_0

    mul-int/lit8 v0, p2, 0x4

    :goto_0
    move v7, v0

    goto :goto_1

    :cond_0
    const/4 v1, 0x3

    if-ne p4, v1, :cond_1

    mul-int/lit8 v2, p2, 0x3

    add-int/2addr v2, v1

    .line 463
    div-int/2addr v2, v0

    mul-int/2addr v0, v2

    goto :goto_0

    :cond_1
    const/4 v0, 0x1

    if-ne p4, v0, :cond_3

    move v7, p2

    :goto_1
    mul-int v0, v7, p3

    .line 470
    invoke-virtual {p1}, Ljava/nio/Buffer;->capacity()I

    move-result v1

    if-ne v1, v0, :cond_2

    .line 474
    iget-object v0, p0, Lcom/google/mediapipe/framework/PacketCreator;->mediapipeGraph:Lcom/google/mediapipe/framework/Graph;

    .line 476
    invoke-virtual {v0}, Lcom/google/mediapipe/framework/Graph;->getNativeHandle()J

    move-result-wide v2

    move-object v1, p0

    move-object v4, p1

    move v5, p2

    move v6, p3

    move v8, p4

    .line 475
    invoke-direct/range {v1 .. v8}, Lcom/google/mediapipe/framework/PacketCreator;->nativeCreateCpuImage(JLjava/nio/ByteBuffer;IIII)J

    move-result-wide p1

    .line 474
    invoke-static {p1, p2}, Lcom/google/mediapipe/framework/Packet;->create(J)Lcom/google/mediapipe/framework/Packet;

    move-result-object p1

    return-object p1

    :cond_2
    move-object v4, p1

    .line 471
    new-instance p1, Ljava/lang/IllegalArgumentException;

    new-instance p2, Ljava/lang/StringBuilder;

    invoke-direct {p2}, Ljava/lang/StringBuilder;-><init>()V

    const-string p3, "The size of the buffer should be: "

    invoke-virtual {p2, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p2, v0}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string p3, " but is "

    invoke-virtual {p2, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 472
    invoke-virtual {v4}, Ljava/nio/Buffer;->capacity()I

    move-result p3

    invoke-virtual {p2, p3}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {p2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p2

    invoke-direct {p1, p2}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1

    :cond_3
    move v8, p4

    .line 467
    new-instance p1, Ljava/lang/IllegalArgumentException;

    new-instance p2, Ljava/lang/StringBuilder;

    invoke-direct {p2}, Ljava/lang/StringBuilder;-><init>()V

    const-string p3, "Channels should be: 1, 3, or 4, but is "

    invoke-virtual {p2, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p2, v8}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {p2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p2

    invoke-direct {p1, p2}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public createInt16(S)Lcom/google/mediapipe/framework/Packet;
    .locals 2

    .line 213
    iget-object v0, p0, Lcom/google/mediapipe/framework/PacketCreator;->mediapipeGraph:Lcom/google/mediapipe/framework/Graph;

    invoke-virtual {v0}, Lcom/google/mediapipe/framework/Graph;->getNativeHandle()J

    move-result-wide v0

    invoke-direct {p0, v0, v1, p1}, Lcom/google/mediapipe/framework/PacketCreator;->nativeCreateInt16(JS)J

    move-result-wide v0

    invoke-static {v0, v1}, Lcom/google/mediapipe/framework/Packet;->create(J)Lcom/google/mediapipe/framework/Packet;

    move-result-object p1

    return-object p1
.end method

.method public createInt16Vector([S)Lcom/google/mediapipe/framework/Packet;
    .locals 1

    .line 241
    new-instance p1, Ljava/lang/UnsupportedOperationException;

    const-string v0, "Not implemented yet"

    invoke-direct {p1, v0}, Ljava/lang/UnsupportedOperationException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public createInt32(I)Lcom/google/mediapipe/framework/Packet;
    .locals 2

    .line 217
    iget-object v0, p0, Lcom/google/mediapipe/framework/PacketCreator;->mediapipeGraph:Lcom/google/mediapipe/framework/Graph;

    invoke-virtual {v0}, Lcom/google/mediapipe/framework/Graph;->getNativeHandle()J

    move-result-wide v0

    invoke-direct {p0, v0, v1, p1}, Lcom/google/mediapipe/framework/PacketCreator;->nativeCreateInt32(JI)J

    move-result-wide v0

    invoke-static {v0, v1}, Lcom/google/mediapipe/framework/Packet;->create(J)Lcom/google/mediapipe/framework/Packet;

    move-result-object p1

    return-object p1
.end method

.method public createInt32Array([I)Lcom/google/mediapipe/framework/Packet;
    .locals 2

    .line 261
    iget-object v0, p0, Lcom/google/mediapipe/framework/PacketCreator;->mediapipeGraph:Lcom/google/mediapipe/framework/Graph;

    invoke-virtual {v0}, Lcom/google/mediapipe/framework/Graph;->getNativeHandle()J

    move-result-wide v0

    invoke-direct {p0, v0, v1, p1}, Lcom/google/mediapipe/framework/PacketCreator;->nativeCreateInt32Array(J[I)J

    move-result-wide v0

    invoke-static {v0, v1}, Lcom/google/mediapipe/framework/Packet;->create(J)Lcom/google/mediapipe/framework/Packet;

    move-result-object p1

    return-object p1
.end method

.method public createInt32Pair(II)Lcom/google/mediapipe/framework/Packet;
    .locals 2

    .line 265
    iget-object v0, p0, Lcom/google/mediapipe/framework/PacketCreator;->mediapipeGraph:Lcom/google/mediapipe/framework/Graph;

    invoke-virtual {v0}, Lcom/google/mediapipe/framework/Graph;->getNativeHandle()J

    move-result-wide v0

    invoke-direct {p0, v0, v1, p1, p2}, Lcom/google/mediapipe/framework/PacketCreator;->nativeCreateInt32Pair(JII)J

    move-result-wide p1

    invoke-static {p1, p2}, Lcom/google/mediapipe/framework/Packet;->create(J)Lcom/google/mediapipe/framework/Packet;

    move-result-object p1

    return-object p1
.end method

.method public createInt32Vector([I)Lcom/google/mediapipe/framework/Packet;
    .locals 1

    .line 245
    new-instance p1, Ljava/lang/UnsupportedOperationException;

    const-string v0, "Not implemented yet"

    invoke-direct {p1, v0}, Ljava/lang/UnsupportedOperationException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public createInt64(J)Lcom/google/mediapipe/framework/Packet;
    .locals 2

    .line 221
    iget-object v0, p0, Lcom/google/mediapipe/framework/PacketCreator;->mediapipeGraph:Lcom/google/mediapipe/framework/Graph;

    invoke-virtual {v0}, Lcom/google/mediapipe/framework/Graph;->getNativeHandle()J

    move-result-wide v0

    invoke-direct {p0, v0, v1, p1, p2}, Lcom/google/mediapipe/framework/PacketCreator;->nativeCreateInt64(JJ)J

    move-result-wide p1

    invoke-static {p1, p2}, Lcom/google/mediapipe/framework/Packet;->create(J)Lcom/google/mediapipe/framework/Packet;

    move-result-object p1

    return-object p1
.end method

.method public createInt64Vector([J)Lcom/google/mediapipe/framework/Packet;
    .locals 1

    .line 249
    new-instance p1, Ljava/lang/UnsupportedOperationException;

    const-string v0, "Not implemented yet"

    invoke-direct {p1, v0}, Ljava/lang/UnsupportedOperationException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public createMatrix(II[F)Lcom/google/mediapipe/framework/Packet;
    .locals 7

    .line 298
    iget-object v0, p0, Lcom/google/mediapipe/framework/PacketCreator;->mediapipeGraph:Lcom/google/mediapipe/framework/Graph;

    invoke-virtual {v0}, Lcom/google/mediapipe/framework/Graph;->getNativeHandle()J

    move-result-wide v2

    move-object v1, p0

    move v4, p1

    move v5, p2

    move-object v6, p3

    invoke-direct/range {v1 .. v6}, Lcom/google/mediapipe/framework/PacketCreator;->nativeCreateMatrix(JII[F)J

    move-result-wide p1

    invoke-static {p1, p2}, Lcom/google/mediapipe/framework/Packet;->create(J)Lcom/google/mediapipe/framework/Packet;

    move-result-object p1

    return-object p1
.end method

.method public createProto(Lcom/google/protobuf/MessageLite;)Lcom/google/mediapipe/framework/Packet;
    .locals 2

    .line 315
    invoke-static {p1}, Lcom/google/mediapipe/framework/ProtoUtil;->pack(Lcom/google/protobuf/MessageLite;)Lcom/google/mediapipe/framework/ProtoUtil$SerializedMessage;

    move-result-object p1

    .line 316
    iget-object v0, p0, Lcom/google/mediapipe/framework/PacketCreator;->mediapipeGraph:Lcom/google/mediapipe/framework/Graph;

    invoke-virtual {v0}, Lcom/google/mediapipe/framework/Graph;->getNativeHandle()J

    move-result-wide v0

    invoke-direct {p0, v0, v1, p1}, Lcom/google/mediapipe/framework/PacketCreator;->nativeCreateProto(JLcom/google/mediapipe/framework/ProtoUtil$SerializedMessage;)J

    move-result-wide v0

    invoke-static {v0, v1}, Lcom/google/mediapipe/framework/Packet;->create(J)Lcom/google/mediapipe/framework/Packet;

    move-result-object p1

    return-object p1
.end method

.method public createReferencePacket(Lcom/google/mediapipe/framework/Packet;)Lcom/google/mediapipe/framework/Packet;
    .locals 4

    .line 69
    iget-object v0, p0, Lcom/google/mediapipe/framework/PacketCreator;->mediapipeGraph:Lcom/google/mediapipe/framework/Graph;

    .line 70
    invoke-virtual {v0}, Lcom/google/mediapipe/framework/Graph;->getNativeHandle()J

    move-result-wide v0

    invoke-virtual {p1}, Lcom/google/mediapipe/framework/Packet;->getNativeHandle()J

    move-result-wide v2

    invoke-direct {p0, v0, v1, v2, v3}, Lcom/google/mediapipe/framework/PacketCreator;->nativeCreateReferencePacket(JJ)J

    move-result-wide v0

    .line 69
    invoke-static {v0, v1}, Lcom/google/mediapipe/framework/Packet;->create(J)Lcom/google/mediapipe/framework/Packet;

    move-result-object p1

    return-object p1
.end method

.method public createRgbImage(Ljava/nio/ByteBuffer;II)Lcom/google/mediapipe/framework/Packet;
    .locals 7

    mul-int/lit8 v0, p2, 0x3

    add-int/lit8 v0, v0, 0x3

    .line 80
    div-int/lit8 v0, v0, 0x4

    mul-int/lit8 v0, v0, 0x4

    mul-int/2addr v0, p3

    .line 81
    invoke-virtual {p1}, Ljava/nio/Buffer;->capacity()I

    move-result v1

    if-ne v0, v1, :cond_0

    .line 88
    iget-object v0, p0, Lcom/google/mediapipe/framework/PacketCreator;->mediapipeGraph:Lcom/google/mediapipe/framework/Graph;

    .line 89
    invoke-virtual {v0}, Lcom/google/mediapipe/framework/Graph;->getNativeHandle()J

    move-result-wide v2

    move-object v1, p0

    move-object v4, p1

    move v5, p2

    move v6, p3

    invoke-direct/range {v1 .. v6}, Lcom/google/mediapipe/framework/PacketCreator;->nativeCreateRgbImage(JLjava/nio/ByteBuffer;II)J

    move-result-wide p1

    .line 88
    invoke-static {p1, p2}, Lcom/google/mediapipe/framework/Packet;->create(J)Lcom/google/mediapipe/framework/Packet;

    move-result-object p1

    return-object p1

    :cond_0
    move-object v4, p1

    .line 82
    new-instance p1, Ljava/lang/IllegalArgumentException;

    new-instance p2, Ljava/lang/StringBuilder;

    invoke-direct {p2}, Ljava/lang/StringBuilder;-><init>()V

    const-string p3, "The size of the buffer should be: "

    invoke-virtual {p2, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p2, v0}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string p3, " but is "

    invoke-virtual {p2, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 86
    invoke-virtual {v4}, Ljava/nio/Buffer;->capacity()I

    move-result p3

    invoke-virtual {p2, p3}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {p2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p2

    invoke-direct {p1, p2}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public createRgbImageFromRgba(Ljava/nio/ByteBuffer;II)Lcom/google/mediapipe/framework/Packet;
    .locals 7

    mul-int v0, p2, p3

    mul-int/lit8 v0, v0, 0x4

    .line 153
    invoke-virtual {p1}, Ljava/nio/Buffer;->capacity()I

    move-result v1

    if-ne v0, v1, :cond_0

    .line 160
    iget-object v0, p0, Lcom/google/mediapipe/framework/PacketCreator;->mediapipeGraph:Lcom/google/mediapipe/framework/Graph;

    .line 161
    invoke-virtual {v0}, Lcom/google/mediapipe/framework/Graph;->getNativeHandle()J

    move-result-wide v2

    move-object v1, p0

    move-object v4, p1

    move v5, p2

    move v6, p3

    invoke-direct/range {v1 .. v6}, Lcom/google/mediapipe/framework/PacketCreator;->nativeCreateRgbImageFromRgba(JLjava/nio/ByteBuffer;II)J

    move-result-wide p1

    .line 160
    invoke-static {p1, p2}, Lcom/google/mediapipe/framework/Packet;->create(J)Lcom/google/mediapipe/framework/Packet;

    move-result-object p1

    return-object p1

    :cond_0
    move-object v4, p1

    .line 154
    new-instance p1, Ljava/lang/IllegalArgumentException;

    new-instance p2, Ljava/lang/StringBuilder;

    invoke-direct {p2}, Ljava/lang/StringBuilder;-><init>()V

    const-string p3, "The size of the buffer should be: "

    invoke-virtual {p2, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p2, v0}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string p3, " but is "

    invoke-virtual {p2, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 158
    invoke-virtual {v4}, Ljava/nio/Buffer;->capacity()I

    move-result p3

    invoke-virtual {p2, p3}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {p2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p2

    invoke-direct {p1, p2}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public createRgbaImageFrame(Ljava/nio/ByteBuffer;II)Lcom/google/mediapipe/framework/Packet;
    .locals 7

    .line 184
    invoke-virtual {p1}, Ljava/nio/Buffer;->capacity()I

    move-result v0

    mul-int v1, p2, p3

    mul-int/lit8 v1, v1, 0x4

    if-ne v0, v1, :cond_0

    .line 191
    iget-object v0, p0, Lcom/google/mediapipe/framework/PacketCreator;->mediapipeGraph:Lcom/google/mediapipe/framework/Graph;

    .line 192
    invoke-virtual {v0}, Lcom/google/mediapipe/framework/Graph;->getNativeHandle()J

    move-result-wide v2

    move-object v1, p0

    move-object v4, p1

    move v5, p2

    move v6, p3

    invoke-direct/range {v1 .. v6}, Lcom/google/mediapipe/framework/PacketCreator;->nativeCreateRgbaImageFrame(JLjava/nio/ByteBuffer;II)J

    move-result-wide p1

    .line 191
    invoke-static {p1, p2}, Lcom/google/mediapipe/framework/Packet;->create(J)Lcom/google/mediapipe/framework/Packet;

    move-result-object p1

    return-object p1

    :cond_0
    move-object v4, p1

    .line 185
    new-instance p1, Ljava/lang/IllegalArgumentException;

    new-instance p2, Ljava/lang/StringBuilder;

    invoke-direct {p2}, Ljava/lang/StringBuilder;-><init>()V

    const-string p3, "The size of the buffer should be: "

    invoke-virtual {p2, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p2, v1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string p3, " but is "

    invoke-virtual {p2, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 189
    invoke-virtual {v4}, Ljava/nio/Buffer;->capacity()I

    move-result p3

    invoke-virtual {p2, p3}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {p2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p2

    invoke-direct {p1, p2}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public createSerializedProto(Lcom/google/protobuf/MessageLite;)Lcom/google/mediapipe/framework/Packet;
    .locals 2

    .line 303
    iget-object v0, p0, Lcom/google/mediapipe/framework/PacketCreator;->mediapipeGraph:Lcom/google/mediapipe/framework/Graph;

    .line 304
    invoke-virtual {v0}, Lcom/google/mediapipe/framework/Graph;->getNativeHandle()J

    move-result-wide v0

    invoke-interface {p1}, Lcom/google/protobuf/MessageLite;->toByteArray()[B

    move-result-object p1

    invoke-direct {p0, v0, v1, p1}, Lcom/google/mediapipe/framework/PacketCreator;->nativeCreateStringFromByteArray(J[B)J

    move-result-wide v0

    .line 303
    invoke-static {v0, v1}, Lcom/google/mediapipe/framework/Packet;->create(J)Lcom/google/mediapipe/framework/Packet;

    move-result-object p1

    return-object p1
.end method

.method public createString(Ljava/lang/String;)Lcom/google/mediapipe/framework/Packet;
    .locals 2

    .line 237
    iget-object v0, p0, Lcom/google/mediapipe/framework/PacketCreator;->mediapipeGraph:Lcom/google/mediapipe/framework/Graph;

    invoke-virtual {v0}, Lcom/google/mediapipe/framework/Graph;->getNativeHandle()J

    move-result-wide v0

    invoke-direct {p0, v0, v1, p1}, Lcom/google/mediapipe/framework/PacketCreator;->nativeCreateString(JLjava/lang/String;)J

    move-result-wide v0

    invoke-static {v0, v1}, Lcom/google/mediapipe/framework/Packet;->create(J)Lcom/google/mediapipe/framework/Packet;

    move-result-object p1

    return-object p1
.end method

.method public createTimeSeriesHeader(ID)Lcom/google/mediapipe/framework/Packet;
    .locals 7

    .line 293
    iget-object v0, p0, Lcom/google/mediapipe/framework/PacketCreator;->mediapipeGraph:Lcom/google/mediapipe/framework/Graph;

    .line 294
    invoke-virtual {v0}, Lcom/google/mediapipe/framework/Graph;->getNativeHandle()J

    move-result-wide v2

    move-object v1, p0

    move v4, p1

    move-wide v5, p2

    invoke-direct/range {v1 .. v6}, Lcom/google/mediapipe/framework/PacketCreator;->nativeCreateTimeSeriesHeader(JID)J

    move-result-wide p1

    .line 293
    invoke-static {p1, p2}, Lcom/google/mediapipe/framework/Packet;->create(J)Lcom/google/mediapipe/framework/Packet;

    move-result-object p1

    return-object p1
.end method

.method public createVideoHeader(II)Lcom/google/mediapipe/framework/Packet;
    .locals 2

    .line 283
    iget-object v0, p0, Lcom/google/mediapipe/framework/PacketCreator;->mediapipeGraph:Lcom/google/mediapipe/framework/Graph;

    invoke-virtual {v0}, Lcom/google/mediapipe/framework/Graph;->getNativeHandle()J

    move-result-wide v0

    invoke-direct {p0, v0, v1, p1, p2}, Lcom/google/mediapipe/framework/PacketCreator;->nativeCreateVideoHeader(JII)J

    move-result-wide p1

    invoke-static {p1, p2}, Lcom/google/mediapipe/framework/Packet;->create(J)Lcom/google/mediapipe/framework/Packet;

    move-result-object p1

    return-object p1
.end method
