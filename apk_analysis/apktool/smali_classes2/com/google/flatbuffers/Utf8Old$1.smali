.class Lcom/google/flatbuffers/Utf8Old$1;
.super Ljava/lang/ThreadLocal;
.source "Utf8Old.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/flatbuffers/Utf8Old;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/lang/ThreadLocal<",
        "Lcom/google/flatbuffers/Utf8Old$Cache;",
        ">;"
    }
.end annotation


# direct methods
.method constructor <init>()V
    .locals 0

    .line 48
    invoke-direct {p0}, Ljava/lang/ThreadLocal;-><init>()V

    return-void
.end method


# virtual methods
.method protected initialValue()Lcom/google/flatbuffers/Utf8Old$Cache;
    .locals 1

    .line 51
    new-instance v0, Lcom/google/flatbuffers/Utf8Old$Cache;

    invoke-direct {v0}, Lcom/google/flatbuffers/Utf8Old$Cache;-><init>()V

    return-object v0
.end method

.method protected bridge synthetic initialValue()Ljava/lang/Object;
    .locals 1

    .line 48
    invoke-virtual {p0}, Lcom/google/flatbuffers/Utf8Old$1;->initialValue()Lcom/google/flatbuffers/Utf8Old$Cache;

    move-result-object v0

    return-object v0
.end method
