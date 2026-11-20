.class final Lcom/scanflow/datacapture/barinternal/okio/internal/ResourceFileSystem$toJarRoot$zip$1;
.super Lkotlin/jvm/internal/Lambda;
.source "ResourceFileSystem.kt"

# interfaces
.implements Lkotlin/jvm/functions/Function1;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/scanflow/datacapture/barinternal/okio/internal/ResourceFileSystem;->toJarRoot(Ljava/net/URL;)Lcom/scanflow/datacapture/barinternal/kotlin/Pair;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x18
    name = null
.end annotation


# static fields
.field public static final INSTANCE:Lcom/scanflow/datacapture/barinternal/okio/internal/ResourceFileSystem$toJarRoot$zip$1;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .line 0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/okio/internal/ResourceFileSystem$toJarRoot$zip$1;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/okio/internal/ResourceFileSystem$toJarRoot$zip$1;-><init>()V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/okio/internal/ResourceFileSystem$toJarRoot$zip$1;->INSTANCE:Lcom/scanflow/datacapture/barinternal/okio/internal/ResourceFileSystem$toJarRoot$zip$1;

    return-void
.end method

.method constructor <init>()V
    .locals 1

    const/4 v0, 0x1

    .line 0
    invoke-direct {p0, v0}, Lkotlin/jvm/internal/Lambda;-><init>(I)V

    return-void
.end method


# virtual methods
.method public final invoke(Lcom/scanflow/datacapture/barinternal/okio/internal/ZipEntry;)Ljava/lang/Boolean;
    .locals 1

    const-string v0, "entry"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 199
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/okio/internal/ResourceFileSystem;->access$getCompanion$p()Lcom/scanflow/datacapture/barinternal/okio/internal/ResourceFileSystem$Companion;

    move-result-object v0

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/okio/internal/ZipEntry;->getCanonicalPath()Lokio/Path;

    move-result-object p1

    invoke-static {v0, p1}, Lcom/scanflow/datacapture/barinternal/okio/internal/ResourceFileSystem$Companion;->access$keepPath(Lcom/scanflow/datacapture/barinternal/okio/internal/ResourceFileSystem$Companion;Lokio/Path;)Z

    move-result p1

    invoke-static {p1}, Ljava/lang/Boolean;->valueOf(Z)Ljava/lang/Boolean;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic invoke(Ljava/lang/Object;)Ljava/lang/Object;
    .locals 0

    .line 196
    check-cast p1, Lcom/scanflow/datacapture/barinternal/okio/internal/ZipEntry;

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/okio/internal/ResourceFileSystem$toJarRoot$zip$1;->invoke(Lcom/scanflow/datacapture/barinternal/okio/internal/ZipEntry;)Ljava/lang/Boolean;

    move-result-object p1

    return-object p1
.end method
