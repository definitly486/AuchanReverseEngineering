.class final Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/CacheEntry;
.super Ljava/lang/Object;
.source "Caching.kt"


# instance fields
.field public final serializer:Lkotlinx/serialization/KSerializer;


# direct methods
.method public constructor <init>(Lkotlinx/serialization/KSerializer;)V
    .locals 0

    .line 169
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/CacheEntry;->serializer:Lkotlinx/serialization/KSerializer;

    return-void
.end method
