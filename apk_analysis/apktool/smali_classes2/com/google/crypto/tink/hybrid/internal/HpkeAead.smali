.class public interface abstract Lcom/google/crypto/tink/hybrid/internal/HpkeAead;
.super Ljava/lang/Object;
.source "HpkeAead.java"


# annotations
.annotation runtime Lcom/google/errorprone/annotations/Immutable;
.end annotation


# virtual methods
.method public abstract getAeadId()[B
.end method

.method public abstract getKeyLength()I
.end method

.method public abstract getNonceLength()I
.end method

.method public abstract open([B[B[BI[B)[B
.end method

.method public open([B[B[B[B)[B
    .locals 6

    const/4 v4, 0x0

    move-object v0, p0

    move-object v1, p1

    move-object v2, p2

    move-object v3, p3

    move-object v5, p4

    .line 55
    invoke-interface/range {v0 .. v5}, Lcom/google/crypto/tink/hybrid/internal/HpkeAead;->open([B[B[BI[B)[B

    move-result-object p1

    return-object p1
.end method

.method public abstract seal([B[B[BI[B)[B
.end method

.method public seal([B[B[B[B)[B
    .locals 6

    const/4 v4, 0x0

    move-object v0, p0

    move-object v1, p1

    move-object v2, p2

    move-object v3, p3

    move-object v5, p4

    .line 39
    invoke-interface/range {v0 .. v5}, Lcom/google/crypto/tink/hybrid/internal/HpkeAead;->seal([B[B[BI[B)[B

    move-result-object p1

    return-object p1
.end method
